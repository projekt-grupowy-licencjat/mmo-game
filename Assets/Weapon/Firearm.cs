using Item;
using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Firearm")]
public class Firearm : Weapon {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 barrelPos;
    [Range(0.1f, 2f)] [SerializeField] private float fireRate;
    [SerializeField] private bool automatic;
    private float _fireTimer;
    private GameObject _barrel;
    
    public override Transform Setup(GameObject parent) {
        _barrel = new GameObject("barrel");
        _barrel.transform.SetParent(parent.transform);
        _barrel.transform.localPosition = barrelPos;
        return _barrel.transform;
    }
    
    public override void Attack(Transform barrel) {
        if (_fireTimer <= 0f && automatic) {
            var go = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            go.GetComponent<NetworkObject>().Spawn();
            _fireTimer = fireRate;
        }
        else if (_fireTimer <= 0f && !automatic) {
            var go = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            go.GetComponent<NetworkObject>().Spawn();
            _fireTimer = fireRate;
        }
        else _fireTimer -= Time.deltaTime;
    }
}
