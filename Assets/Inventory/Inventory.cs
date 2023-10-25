using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        // Refers to the id in the database, eg. player or npc items - might be useless
        public long entityID;

        public List<Item.Item> items;
    }
}