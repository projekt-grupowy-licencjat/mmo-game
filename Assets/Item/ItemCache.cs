using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AddressableAssets.Build;
#endif
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.TextCore.Text;

namespace Item
{
    public class ItemCache : MonoBehaviour
    {
        public static ItemCache Instance { get; private set; }

        public ItemDataCache toLoad;
        
        public Dictionary<string, ItemData> itemScriptableObjects = new Dictionary<string, ItemData>();

        
        private void Start()
        {
            // TODO change to addressables
            if (Instance != this)
            {
                Instance = this;
            }

            foreach (var item in toLoad.forLoad)
            {
                itemScriptableObjects.Add(item.itemName, item);
            }
            
        }
    }
}