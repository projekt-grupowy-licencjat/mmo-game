using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace Item
{
    public class ItemManager : NetworkBehaviour
    {
        public Inventory.Inventory localInventory;
        public GameObject genericItemPrefab;
        public static ItemManager Instance { get; private set; }
        
        [SerializeField] private double activePlayerDistance = 5f;
        [SerializeField] private float secondsInterval = 1f;

        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }
            
            StartCoroutine(LoadLocalInventory(secondsInterval));
        }

        private void Update()
        {
            if (transform.childCount == 0) return;
            var result = CalculateItemClosestToPlayer();
            
            if (result.Item1 && Input.GetKeyDown("e"))
            {
                HandlePickup(result.Item2);
            }
        }
        // TODO
        private void HandlePickup(ItemObject item)
        {
            var o = item.gameObject;
            localInventory.AddItem(item.data);
            // TODO PRESENTATION ONLY
            var weaponStats = localInventory.gameObject.GetComponentInChildren<WeaponStats>();
            weaponStats.ChangeWeapon((Weapon) item.data);
            if (IsServer)
            {
                SetWeaponClientRpc(weaponStats.transform.parent.gameObject, item.data.itemName);
            }
            else {
                SetWeaponServerRpc(weaponStats.transform.parent.gameObject, item.data.itemName);
            }
            // TODO
            
            if (IsServer) o.GetComponent<NetworkObject>().Despawn();
            else HandlePickupServerRpc(o.GetComponent<NetworkObject>());
        }

        [ClientRpc]
        private void SetWeaponClientRpc(NetworkObjectReference netRef, string itemName)
        {
            NetworkObject player;
            bool result = netRef.TryGet(out player, NetworkManager.Singleton);
            if (!result)
            {
                Debug.LogError("Couldn't find item.");
                return;
            }

            var weapon = ItemCache.Instance.itemScriptableObjects[itemName];
            player.GetComponentInChildren<WeaponStats>().ChangeWeapon((Weapon) weapon);
        }

        [ServerRpc(RequireOwnership = false)]
        private void SetWeaponServerRpc(NetworkObjectReference netRef,
            string itemName)
        {
            NetworkObject player;
            bool result = netRef.TryGet(out player, NetworkManager.Singleton);
            if (!result)
            {
                Debug.LogError("Couldn't find item.");
                return;
            }
            SetWeaponClientRpc(netRef, itemName);

            var weapon = ItemCache.Instance.itemScriptableObjects[itemName];
            player.GetComponentInChildren<WeaponStats>().ChangeWeapon((Weapon) weapon);
        }
        // TODO
        
        [ServerRpc(RequireOwnership = false)]
        private void HandlePickupServerRpc(NetworkObjectReference netRef)
        {
            NetworkObject networkObject;
            bool result = netRef.TryGet(out networkObject, NetworkManager.Singleton);
            if (!result)
            {
                Debug.LogError("Couldn't find item.");
                return;
            }
            networkObject.Despawn();
        }
        
        
        public void CreateItem(ItemData itemData)
        {
            CreateItemServerRpc(itemData.itemName);
        }
        
        public void CreateItem(ItemData itemData, float x, float y)
        {
            CreateItemServerRpc(itemData.itemName, x, y);
        }

        [ClientRpc]
        public void SetPropertyClientRpc(string itemName, NetworkObjectReference netRef)
        {
            NetworkObject networkObject;
            bool result = netRef.TryGet(out networkObject, NetworkManager.Singleton);
            if (!result)
            {
                Debug.LogError("Couldn't find item.");
                return;
            }

            var itemObject = networkObject.gameObject.GetComponent<ItemObject>();
            var data = ItemCache.Instance.itemScriptableObjects[itemName];
            itemObject.Init(data);
        }

        [ServerRpc(RequireOwnership = false)]
        private void CreateItemServerRpc(string itemName)
        {
            var data = ItemCache.Instance.itemScriptableObjects[itemName];
            
            var itemGameObject = Instantiate(genericItemPrefab);
            var networkObject = itemGameObject.GetComponent<NetworkObject>();
            networkObject.Spawn();
            networkObject.TrySetParent(transform);
            var itemObject = itemGameObject.GetComponent<ItemObject>();
            
            if (IsServer) itemObject.Init(data);
            SetPropertyClientRpc(data.itemName, networkObject);
        }
        
        [ServerRpc(RequireOwnership = false)]
        private void CreateItemServerRpc(string itemName, float x, float y)
        {
            var data = ItemCache.Instance.itemScriptableObjects[itemName];
            
            var itemGameObject = Instantiate(genericItemPrefab);
            var networkObject = itemGameObject.GetComponent<NetworkObject>();
            networkObject.Spawn();
            networkObject.TrySetParent(transform);
            var itemObject = itemGameObject.GetComponent<ItemObject>();
            if (IsServer) itemObject.Init(data);
            
            networkObject.transform.position = new Vector2(x, y);
            
            SetPropertyClientRpc(data.itemName, networkObject);
        }
        
        private (bool, ItemObject) CalculateItemClosestToPlayer()
        {
            double currentMin = CalculateDistance(transform.GetChild(0).gameObject);
            GameObject currentGameObject = transform.GetChild(0).gameObject;

            foreach (var itemTransform in gameObject.GetComponentsInChildren<Transform>().Skip(1))
            {
                var item = itemTransform.gameObject;
                
                var result = CalculateDistance(item);

                if (result < currentMin)
                {
                    currentMin = result;
                    currentGameObject = item;
                }
            }

            bool isCloseEnough = currentMin <= activePlayerDistance;
            return (isCloseEnough, currentGameObject.GetComponent<ItemObject>());
        }
        
        private double CalculateDistance(GameObject item) 
        {
            var playerPosition = NetworkManager.Singleton.LocalClient.PlayerObject.transform.position;
            var itemPosition = item.transform.position;
            var subtractionX = playerPosition.x - itemPosition.x;
            var subtractionY = playerPosition.y - itemPosition.y;
            return Math.Sqrt(Math.Pow(subtractionX, 2) + Math.Pow(subtractionY, 2));
        }
        
        private IEnumerator LoadLocalInventory(float retryInterval)
        {
            
            while (!localInventory)
            {
                var client = NetworkManager.Singleton.LocalClient.PlayerObject;
                if (client) break;
                yield return new WaitForSeconds(retryInterval);
            }

            localInventory = NetworkManager.Singleton.LocalClient
                .PlayerObject
                .GetComponent<Inventory.Inventory>();
        }
    }
}