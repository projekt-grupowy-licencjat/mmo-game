using System;
using Item;
using Unity.Netcode;
using UnityEngine;

public class WeaponStats : NetworkBehaviour {
    [SerializeField] private Weapon weaponData;
    private SpriteRenderer _spriteRenderer;
    private Transform _barrel;

    private void Start() {
        // Set weapon sprite
        if (!IsOwner) return;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponData.itemSprite;
        _barrel = weaponData.Setup(gameObject);
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetMouseButton(0))
        {
            if (IsServer)
                AttackClientRpc();
            else
                AttackServerRpc();
        }
        // if (IsOwner) AttackServerRpc();
    }

    // TODO figure out client shooting
    [ServerRpc(RequireOwnership = false)]
    private void AttackServerRpc() {
        weaponData.Attack(transform);
        // AttackClientRpc();
    }
    
    [ClientRpc]
    private void AttackClientRpc()
    {
        weaponData.Attack(transform);
    }
}
