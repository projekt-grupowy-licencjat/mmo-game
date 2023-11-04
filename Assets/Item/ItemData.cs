using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public abstract class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite itemSprite;
    }

    public abstract class Usable : ItemData
    {
        // TODO: Add arguments here
        public abstract void Use();
    }
    
    [CreateAssetMenu(menuName = "Items/HealingItem")]
    public class HealingItem : Usable
    {
        [SerializeField] private int healValue;
        
        public override void Use()
        {
            Debug.Log("Item used");
        }
    }
}