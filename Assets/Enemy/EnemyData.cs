using Unity.Netcode;
using UnityEngine;
namespace Enemy
{
    public enum EnemyType { Normal, Hard, Boss }
    public enum ActivityState { Idle, Follow, Fight }
    public abstract class EnemyData : ScriptableObject
    {
        public string Name;
        public float Health;
        public float AttackDamage;
        public float DefencePoints;
        public float MovementSpeed;
        public ActivityState ActivityState;
        public EnemyType EnemyType;
        public Inventory.Inventory Inventory;
        public Sprite enemySprite;
        public Animator Animator; // animator contains skin (sprite)

        virtual public void Idle()
        {
            Debug.Log($"Enemy {this.Name} is in {this.ActivityState} mode, should be IDLE");
        }

        public void Follow()
        {
            Debug.Log($"Enemy {this.Name} is in {this.ActivityState} mode, should be FOLLOW");
            
        }

        public void Fight()
        {
            Debug.Log($"Enemy {this.Name} is in {this.ActivityState} mode, should be FIGHT");
        }

        private void Die()
        {
            // todo: trigger death animation
            Debug.Log($"Enemy {this.Name} has died");
            // todo: drop inventory and desintegrate
            
        }

        virtual public void GetDamage()
        {
            
            if (this.Health <= 0)
            {
                this.Die();
            }
            else
            {
                // todo: trigger animation of getting dmg
            }
            Debug.Log($"Received dmg");
        }

    }

    
    
}