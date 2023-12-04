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

    public abstract class Wearable : ItemData {
        
    }
    
    public abstract class Weapon : Wearable {
        // TODO possible additional fields/methods
        public bool isAutomatic;
        public abstract void Attack(Transform barrel);
        public abstract Vector3 GetPosition();
        public abstract void DecreaseTimer();
    }
}