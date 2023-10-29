using System;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu]
    public class Inventory : ScriptableObject
    {
        // Refers to the id in the database, eg. player or npc items - might be useless
        public long entityID;
        
        public List<Item.Item> Items;

        private void Awake()
        {
            Items = new List<Item.Item>();
            var bread = new Bread("Assets/Item/bread.png");
            bread.LoadAsset();
            Items.Add(bread);
            Items.Add(bread);
            Items.Add(bread);
            Items.Add(bread);
        }
    }
}