using UnityEngine;

namespace Item
{
    public abstract class Item
    {
        public Sprite ItemAsset { get; set; }
        public abstract void LoadAsset();
        protected string SpritePath { get; set; }
    }

    public abstract class Usable : Item
    {
        
    }

    public abstract class Weapon : Item
    {
        
    }
    
    public abstract class Wearable : Item
    {
        
    }
    
    public abstract class Misc : Item
    {
        
    }
}