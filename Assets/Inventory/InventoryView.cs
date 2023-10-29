using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public Inventory inventoryObject;
        
        private AsyncOperationHandle<Inventory> _handle;
        private GameObject _itemListPanel;
        
        void Start()
        {
            _itemListPanel = transform.Find("Canvas/ItemList").gameObject;
            _handle = Addressables.LoadAssetAsync<Inventory>("Assets/Inventory/PlayerInventory.asset");
            _handle.Completed += HandleCompleted;
        }
        
        private void HandleCompleted(AsyncOperationHandle<Inventory> operation)
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