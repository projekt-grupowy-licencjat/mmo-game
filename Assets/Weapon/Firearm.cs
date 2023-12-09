using Item;
using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Firearm")]
public class Firearm : Weapon {
    [SerializeField] private GameObject bulletPrefab;
    
    public override void Attack(Transform barrel) {
        var go = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        go.GetComponent<NetworkObject>().Spawn();
    }
}
