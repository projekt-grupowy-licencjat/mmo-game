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
        public Inventory.Inventory Inventory;
        private Animator _animator; // animator contains skin (sprite)
        private bool isHitAnimationPlaying = false;
        

        void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<BoxCollider2D>();
            _spriteRenderer.sprite = data.sprite;
            

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // wip, placeholder for animation
            if (other.gameObject.name == "Bullet(Clone)")
            {
                _animator.Play("hit",  -1, 0f);
                isHitAnimationPlaying = true;
                Invoke("EndHitAnimation", _animator.GetCurrentAnimatorStateInfo(0).length);
                data.ReceiveDamage();
            }
        }
        
        private void EndHitAnimation()
        {
            // Wywołaj tę funkcję, aby zresetować animację do poprzedniej
            isHitAnimationPlaying = false;
            _animator.Play("idle");
        }

        // Funkcja obsługi zdarzeń do zarejestrowania w animatorze
        private void AnimationEventReceived(string message)
        {
            if (message == "EndHitAnimationEvent")
            {
                EndHitAnimation();
            }
        }
        
    } 
}