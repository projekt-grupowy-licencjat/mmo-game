using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Item
{
    public class DebugItemSpawner : NetworkBehaviour
    {
        public List<ItemData> spawnItems;
        private float timer = 10f;
        private bool notDone = true;
        
        private void Update()
        {
            if (!IsServer) return;
            if (timer <= 0 && notDone)
            {
                foreach (var item in spawnItems)
                {
                    ItemManager.Instance.CreateItem(item, 2, 2);
                }
                notDone = false;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}