using Unity.Netcode;
using UnityEngine;

namespace Enemy
{
    public enum EnemyType { Normal, Hard, Boss }
    public abstract class EnemyData : ScriptableObject 
    {
        public string Name { get; private set; }
        public float Health { get; private set; }
        public float AttackDamage { get; private set; }
        public float DefencePoints { get; private set; }
        public float MovementSpeed { get; private set; }
        public EnemyType EnemyType { get; private set; }
        public Inventory.Inventory Inventory { get; private set; }
        public Animator animation; // animator contains skin (sprite)

        public void Idle()
        {
            
        }

        public void Follow()
        {
            
        }

        public void Attack()
        {
            
        }

        private void Die()
        {
            // todo: play death animation 
            // animation.SetTrigger("Die");
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
                animation.SetTrigger("Hit");
            }
            Debug.Log("Received ");
        }

    }

    
    
}