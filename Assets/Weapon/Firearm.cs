using Item;
using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Firearm")]
public class Firearm : Weapon {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 attackPointPosition;
    [Range(0.05f, 2f)] [SerializeField] private float fireRate;
    private float _fireTimer;
    
    public override Vector3 GetPosition() {
        return attackPointPosition;
    }
    
    public override void Attack(Transform barrel) {
        if (!(_fireTimer <= 0f)) return;
        var go = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        go.GetComponent<NetworkObject>().Spawn();
        _fireTimer = fireRate;
    }
    
    public override void DecreaseTimer() {
        if (_fireTimer <= 0f) return;
        _fireTimer -= Time.deltaTime;
    }
}
