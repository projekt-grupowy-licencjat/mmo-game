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
        
        private void Start()
        {
            inventory = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<global::Inventory.Inventory>();
            
            foreach (var item in inventory.Items)
            {
                var itemPanel = Instantiate(itemPanelPrefab, content.transform, false);
                var inventoryElement = itemPanel.GetComponent<InventoryElement>();
                inventoryElement.itemData = item;
                inventoryElement.playerInventory = inventory;
            }
        }
    }
}