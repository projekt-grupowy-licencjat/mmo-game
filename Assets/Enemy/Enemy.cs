using Unity.Netcode;
using UnityEngine;

namespace Enemy
{
    public enum EnemyType { Normal, Hard, Boss }
    public abstract class Enemy : ScriptableObject 
    {
        
        public float Health { get; private set; }
        public float AttackDamage { get; private set; }
        public float DefencePoints { get; private set; }
        public float MovementSpeed { get; private set; }
        public EnemyType EnemyType { get; private set; }
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

        public void Die()
        {
            
        }

        public void GetDamage()
        {
            
        }

    }

    
    
}