using Unity.Netcode;
using UnityEngine;

namespace UIManager.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public global::Inventory.Inventory inventory;
        // Tells the inventory view to which prefab map the items
        public GameObject itemPanelPrefab;
        public GameObject content;
        public GameObject weaponPanel;
        
        private void Start()
        {
            var localPlayer = NetworkManager.Singleton.LocalClient.PlayerObject;
            inventory = localPlayer.GetComponent<global::Inventory.Inventory>();
            var weaponStats = localPlayer.GetComponentInChildren<WeaponStats>();
            
            foreach (var item in inventory.Items)
            {
                var itemPanel = Instantiate(itemPanelPrefab, content.transform, false);
                var inventoryElement = itemPanel.GetComponent<InventoryElement>();
                inventoryElement.itemData = item;
                inventoryElement.playerInventory = inventory;
                inventoryElement.playerWeapon = weaponStats;
                inventoryElement.weaponPanel = weaponPanel;
            }
        }
    }
}