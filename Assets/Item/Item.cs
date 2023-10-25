using UnityEngine;

namespace Item
{
    public abstract class Item
    {
        // Item id in database
        public long ItemID { get; set; }
        // should be loaded in constructor from the file string
        public string SpritePath { get; set; }
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