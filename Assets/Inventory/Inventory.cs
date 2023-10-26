using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu]
    public class Inventory : ScriptableObject
    {
        // Refers to the id in the database, eg. player or npc items - might be useless
        public long entityID;
        
        public List<Item.Item> Items;
    }
}