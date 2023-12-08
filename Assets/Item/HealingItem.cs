using UnityEngine;

namespace Item
{
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