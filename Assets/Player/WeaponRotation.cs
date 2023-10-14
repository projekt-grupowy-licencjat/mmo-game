using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private new Camera camera;
    private Transform _localTransform;

    private void Start() {
        _localTransform = transform;
        camera = Camera.main;
    }

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 mouseScreenPosition = camera.ScreenToWorldPoint(mousePosition);
        Vector2 position = _localTransform.position;
        
        // Rotate weapon
        var direction = (mouseScreenPosition - position).normalized;
        _localTransform.right = direction;

        // Flip weapon sprite
        var mousePosToPlayer = mouseScreenPosition - position;
        spriteRenderer.flipY = mousePosToPlayer.x < 0;
    }
}
