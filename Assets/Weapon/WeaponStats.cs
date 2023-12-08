using Item;
using Unity.Netcode;
using UnityEngine;

public class WeaponStats : NetworkBehaviour {
    [SerializeField] private Weapon weaponData;
    private SpriteRenderer _spriteRenderer;
    private GameObject _attackPoint;

    private void Start() {
        // Set weapon sprite
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponData.itemSprite;
        SetAttackPointPosition();
    }

    private void Update()
    {
        if (!IsOwner) return;
        weaponData.DecreaseTimer();
        if (Input.GetMouseButtonDown(0) && !weaponData.isAutomatic)
        {
            AttackServerRpc();
        }
        else if (Input.GetMouseButton(0) && weaponData.isAutomatic)
        {
            AttackServerRpc();
        }
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void AttackServerRpc() {
        // TODO Fix not being able to shoot as client when host is paused
        if (IsHost && UIManager.UIManager.Instance.isPaused) return;
        weaponData.Attack(_attackPoint.transform);
    }

    public void SetAttackPointPosition() {
        _attackPoint = transform.GetChild(0).gameObject;
        _attackPoint.transform.localPosition = weaponData.GetPosition();
    }
}
