using Item;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Firearm")]
public class Firearm : Weapon {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 barrelPos;
    [Range(0.1f, 2f)] [SerializeField] private float fireRate;
    private float _fireTimer;
    private GameObject _barrel;

    // TODO probably rework this as it sucks ass - edit: ok reworked a little maybe doesn't suck as much but still don't really like it and it won't really work for melee
    public override Transform Setup(GameObject parent) {
        _barrel = new GameObject("barrel");
        _barrel.transform.SetParent(parent.transform);
        _barrel.transform.localPosition = barrelPos;
        return _barrel.transform;
    }
    
    public override void Attack(Transform barrel) {
        // TODO figure out where to put differentiation between full and semi automatic
        // if (Input.GetMouseButton(0) && _fireTimer <= 0f) {
        //     Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        //     _fireTimer = fireRate;
        // }
        // else {
        //     _fireTimer -= Time.deltaTime;
        // }
        if (Input.GetMouseButtonDown(0) && _fireTimer <= 0f) {
            Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            _fireTimer = fireRate;
        }
        else {
            _fireTimer -= Time.deltaTime;
        }
    }
}
