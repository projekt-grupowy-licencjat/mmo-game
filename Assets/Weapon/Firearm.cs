using Item;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Firearm")]
public class Firearm : Weapon {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3 barrelPos;
    [Range(0.1f, 2f)] [SerializeField] private float fireRate;
    private float _fireTimer;
    private GameObject _barrel;

    // TODO probably rework this as it sucks ass
    public override Transform Setup(GameObject parent) {
        _barrel = new GameObject {
            transform = {
                position = barrelPos
            }
        };
        return Instantiate(_barrel, parent.transform).transform;
    }
    
    public override void Attack(Transform barrel) {
        if (Input.GetMouseButton(0) && _fireTimer <= 0f) {
            Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            _fireTimer = fireRate;
        }
        else {
            _fireTimer -= Time.deltaTime;
        }
    }
}
