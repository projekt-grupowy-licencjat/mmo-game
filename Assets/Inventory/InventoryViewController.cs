using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private GameObject inventoryViewAsset;
        private bool _show;
        private bool _isVisible;
        private GameObject _inventoryView;
        
        private void Start()
        {
            _isVisible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) _show = true;
            if (_show && !_isVisible)
            {
                _inventoryView = Instantiate(inventoryViewAsset);
                _inventoryView.GetComponent<InventoryView>().inventoryObject = inventory;
                _isVisible = true;
                _show = false;
            } 
            else if (Input.GetKeyDown(KeyCode.Escape) && _isVisible)
            {
                Destroy(_inventoryView);
                _isVisible = false;
            }
        }
    }
}
