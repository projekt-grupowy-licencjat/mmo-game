using UnityEngine;

namespace Item
{
    public abstract class Item
    {
        // Item id in database
        public long ItemID;
        // should be loaded in constructor from the file string, TODO: so maybe string path here?
        public Sprite sprite;
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