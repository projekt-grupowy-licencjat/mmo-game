using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Item
{
    public class ItemCache : MonoBehaviour
    {
        public static ItemCache Instance { get; private set; }
        
        public Dictionary<string, ItemData> itemScriptableObjects = new Dictionary<string, ItemData>();

        
        private void Start()
        {
            if (Instance != this)
            {
                Instance = this;
            }
            
            string[] assetNames = AssetDatabase.FindAssets("ItemData", new[] { "Assets/Item/Instances" });
            foreach (string soName in assetNames)
            {
                var soPath    = AssetDatabase.GUIDToAssetPath(soName);
                var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(soPath);
                itemScriptableObjects.Add(itemData.itemName, itemData);
            }
        }
    }
}