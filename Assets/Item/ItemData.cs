using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;

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
        public bool isAutomatic;
        [Range(0.05f, 2f)] public float attackSpeed;
        public float damage;
        public Vector3 attackPointPosition;
        public abstract void Attack(Transform barrel);
    }
}