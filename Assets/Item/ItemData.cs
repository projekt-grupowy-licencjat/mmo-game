using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public abstract class ItemData : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public Sprite itemSprite;
    }

    public abstract class Usable : ItemData
    {
        // TODO: Add arguments here
        public abstract void Use();
    }
}