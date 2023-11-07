using System;
using Network;
using UnityEngine;

namespace UIManager.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public global::Inventory.Inventory inventory;

        private void Start()
        {
            inventory = LocalPlayerSingleton.Instance.LocalPlayer.GetComponent<global::Inventory.Inventory>();
        }
    }
}