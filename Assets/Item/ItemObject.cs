using System;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

namespace Item
{
    // This class represents an item in case of laying on the map to be picked
    // This is the only component needed to be added for a GameObject to be considered 
    // an item - which will ease creation of ItemObjects in runtime.
    public class ItemObject : NetworkBehaviour
    {
        public ItemData data;
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            _spriteRenderer.sprite = data.itemSprite;
            gameObject.AddComponent<NetworkObject>();
        }
    }
}