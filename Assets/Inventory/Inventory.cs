using System.Collections.Generic;
using Item;
using Unity.Netcode;
using UnityEngine;

namespace Inventory
{
    public class Inventory : NetworkBehaviour
    {
        [SerializeField] private List<ItemData> items;

        public void AddItem(ItemData item)
        {
            items.Add(item);
        }
    }
}