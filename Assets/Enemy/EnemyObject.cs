using System;
using Unity.Netcode;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyObject : NetworkBehaviour
    {
        public EnemyData data;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidBody;
        private BoxCollider2D _collider;
        

        void Start()
        {
            data.Animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<BoxCollider2D>();
            _spriteRenderer.sprite = data.enemySprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // wip, placeholder for animation
            if (other.gameObject.name == "Bullet(Clone)")
            {
                _spriteRenderer.color = Color.red;
                data.ReceiveDamage();
            }
            else
            {
                Debug.Log("something went into collision xd");
            }
        }
        
    } 
}