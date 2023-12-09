using Item;
using Unity.Netcode;
using UnityEngine;

public class WeaponStats : NetworkBehaviour {
    [SerializeField] private Weapon weaponData;
    private SpriteRenderer _spriteRenderer;
    private GameObject _attackPoint;
    private float _attackTimer;
    // public CameraShake cameraShake;

    private void Start() {
        SetWeaponAttributes();
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (_attackTimer > 0f) _attackTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && !weaponData.isAutomatic && _attackTimer <= 0f)
        {
            if (UIManager.UIManager.Instance.isPaused) return;
            AttackServerRpc();
            _attackTimer = weaponData.attackSpeed;
        }
        else if (Input.GetMouseButton(0) && weaponData.isAutomatic && _attackTimer <= 0f)
        {
            if (UIManager.UIManager.Instance.isPaused) return;
            AttackServerRpc();
            _attackTimer = weaponData.attackSpeed;
        }
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void AttackServerRpc() {
        weaponData.Attack(_attackPoint.transform);

        // TODO use this somewhere else
        // StartCoroutine(cameraShake.Shake());
    }

    public void SetWeaponAttributes() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponData.itemSprite;
        
        _attackTimer = weaponData.attackSpeed;
        
        _attackPoint = transform.GetChild(0).gameObject;
        _attackPoint.transform.localPosition = weaponData.attackPointPosition;
    }

    
}
