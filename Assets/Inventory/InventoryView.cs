using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public GameObject character;
        
        private Inventory _inventory;
        private GameObject _itemListPanel;
        
        void Start()
        {
            _inventory = character.GetComponent<Inventory>();
            // TODO: should not be dependend on indexes
            _itemListPanel = transform.GetChild(0).GetChild(0).gameObject; 
        }
    }
}