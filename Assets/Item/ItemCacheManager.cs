using Shared;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Item
{
    public class ItemCacheManager : MonoBehaviour
    {
        public static ItemCacheManager Instance { get; private set; }
        public BidirectionalMap<int, ItemData> items = new();

        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }

            int id = 0;
            string[] assetNames = AssetDatabase.FindAssets("ItemData", new[] { "Assets/Item" });
            foreach (string soName in assetNames)
            {
                var soPath = AssetDatabase.GUIDToAssetPath(soName);
                if (soPath == "Assets/Item/ItemData.cs") continue;
                
                var item = AssetDatabase.LoadAssetAtPath<ItemData>(soPath);
                items.Add(id, item);
                id += 1;
            }
        }
    }
}