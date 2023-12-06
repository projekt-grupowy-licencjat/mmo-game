using Unity.Netcode;
using UnityEngine;

namespace Enemy
{
    public enum EnemyType { normal, hard, boss }
    public abstract class Enemy : ScriptableObject 
    {
        
        public float Health { get; private set; }
        public float AttackDamage { get; private set; }
        public float DefencePoints { get; private set; }
        public float MovementSpeed { get; private set; }
        public EnemyType EnemyType { get; private set; }
        public Animator animation; // animator contains skin (sprite)

        void move()
        {
            
        }

        void die()
        {
        }
        
        void getDamage() {}

        void attack()
        {
            
        }
        
        

    }

    
    
}