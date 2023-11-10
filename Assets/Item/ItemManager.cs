using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

namespace Item
{
    public class ItemManager : NetworkBehaviour
    {
        public Inventory.Inventory localInventory;
        public static ItemManager Instance;
        [SerializeField] private List<ItemData> newItems;
        [SerializeField] private List<GameObject> sceneItems; // TODO: Network Variable?
        [SerializeField] private double activePlayerDistance = 5f;
        [SerializeField] private float secondsInterval = 1f;
        
        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }

            foreach (var data in newItems)
            {
                CreateItem(data);
            }

            StartCoroutine(LoadLocalInventory(secondsInterval));
        }

        private void Update()
        {
            if (sceneItems.Count == 0) return;
            var result = CalculateItemClosestToPlayer();
            
            if (result.Item1 && Input.GetKeyDown("e"))
            {
                localInventory.AddItem(result.Item2.data);
                Destroy(gameObject);
            }
        }
        
        public void CreateItem(ItemData itemData)
        {
            var itemGameObject = new GameObject
            {
                transform =
                {
                    parent = transform
                }
            };
            var itemObject = itemGameObject.AddComponent<ItemObject>();
            itemObject.data = itemData;
            
            sceneItems.Add(itemGameObject);
        }

        private (bool, ItemObject) CalculateItemClosestToPlayer()
        {
            double currentMin = CalculateDistance(sceneItems[0]);
            GameObject currentGameObject = sceneItems[0];
            
            foreach (var item in sceneItems.Skip(1))
            {
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