using Item;
using Unity.Netcode;
using UnityEngine;

public class WeaponStats : NetworkBehaviour {
    [SerializeField] private Weapon weaponData;
    private SpriteRenderer _spriteRenderer;
    private GameObject _attackPoint;
    private float _fireTimer;
    // public CameraShake cameraShake;

    private void Start() {
        SetWeaponAttributes();
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (_fireTimer > 0f) _fireTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && !weaponData.isAutomatic && _fireTimer <= 0f)
        {
            if (UIManager.UIManager.Instance.isPaused) return;
            AttackServerRpc();
            _fireTimer = weaponData.fireRate;
        }
        else if (Input.GetMouseButton(0) && weaponData.isAutomatic && _fireTimer <= 0f)
        {
            if (UIManager.UIManager.Instance.isPaused) return;
            AttackServerRpc();
            _fireTimer = weaponData.fireRate;
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
        
        _fireTimer = weaponData.fireRate;
        
        _attackPoint = transform.GetChild(0).gameObject;
        _attackPoint.transform.localPosition = weaponData.attackPointPosition;
    }

    
}
