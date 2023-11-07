using System;
using Unity.Netcode;
using UnityEngine;

namespace Item
{
    public class ItemTestSpawner : NetworkBehaviour
    {
        public ItemData testItemData;
        private void Start()
        {
            
            var bread = new GameObject();
            var breadObject = bread.AddComponent<ItemObject>();
            breadObject.data = testItemData;
            Instantiate(bread);
        }
    }
}