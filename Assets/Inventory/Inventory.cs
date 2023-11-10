using System;
using System.Collections.Generic;
using Item;
using Unity.Netcode;
using UnityEngine;

namespace Inventory
{
    public class Inventory : NetworkBehaviour
    {
        public List<ItemData> Items { get; private set; }

        private void Start()
        {
            if (Items == null) Items = new List<ItemData>();
        }

        public void AddItem(ItemData item)
        {
            Items.Add(item);
        }
    }
}