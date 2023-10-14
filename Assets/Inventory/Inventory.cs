using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Refers to the id in the database, eg. player or npc items
        public long entityID;

        private List<Item.Item> items;
        
        // should load items from server
        private void Start()
        {
            throw new NotImplementedException();
        }
    }
}