using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public Inventory inventoryObject;
        
        private GameObject _itemListPanel;
        
        void Start()
        {
            _itemListPanel = transform.Find("Canvas/ItemList").gameObject; 
        }
    }
}