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

    private void Update() {
        if (IsOwner) weaponData.Attack(_barrel);
        // if (IsOwner) AttackServerRpc();
    }

    // TODO figure out client shooting
    // [ServerRpc]
    // private void AttackServerRpc() {
    //     weaponData.Attack(_barrel);
    // }
}
