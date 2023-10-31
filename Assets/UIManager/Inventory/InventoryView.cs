using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UIManager.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public global::Inventory.Inventory inventoryObject;
        
        private AsyncOperationHandle<global::Inventory.Inventory> _handle;
        private GameObject _itemListPanel;
        
        void Start()
        {
            _itemListPanel = transform.Find("Canvas/ItemList").gameObject;
            _handle = Addressables.LoadAssetAsync<global::Inventory.Inventory>("Assets/Inventory/PlayerInventory.asset");
            _handle.Completed += HandleCompleted;
        }
        
        private void HandleCompleted(AsyncOperationHandle<global::Inventory.Inventory> operation)
        {
            if (operation.Status == AsyncOperationStatus.Succeeded)
            {
                inventoryObject = operation.Result;
                inventoryObject.Items.ForEach((item) =>
                {
                    Debug.Log(item);
                });
            }
            else
            {
                Debug.LogError($"Asset failed to load.");
            }
        }

        // Release asset when parent object is destroyed
        private void OnDestroy()
        {
            Addressables.Release(_handle);
        }
    }
}