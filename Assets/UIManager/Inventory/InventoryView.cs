using Unity.Netcode;
using UnityEngine;

namespace UIManager.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public global::Inventory.Inventory inventory;

        private void Start()
        {
            inventory = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<global::Inventory.Inventory>();
        }
    }
}