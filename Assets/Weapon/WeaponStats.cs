using Item;
using UnityEngine;

public class WeaponStats : MonoBehaviour {
    [SerializeField] private Weapon weaponData;
    private SpriteRenderer _spriteRenderer;
    private Transform _barrel;

    private void Start() {
        // Set weapon sprite
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = weaponData.itemSprite;
        _barrel = weaponData.Setup(gameObject);
    }

    private void Update() {
        weaponData.Attack(_barrel);
    }
}
