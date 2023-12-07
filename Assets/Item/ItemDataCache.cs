using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "ItemDataCache")]
    public class ItemDataCache : ScriptableObject
    {
        public List<ItemData> forLoad;
    }
}