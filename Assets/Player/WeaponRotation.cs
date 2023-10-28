using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private new Camera camera;
    private Transform _localTransform;
    [SerializeField] private float maxThreshold;

    private void Start() {
        _localTransform = transform;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        camera = Camera.main;
    }

    private void Update() {
        Vector2 mouseScreenPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = _localTransform.parent.gameObject.transform.position;
        
        // Rotate weapon
        _localTransform.right =(mouseScreenPosition - (Vector2)transform.position).normalized;
        
        // TODO Rotate around player - W.I.P
        var allowedPos = mouseScreenPosition - position;
        allowedPos = Vector3.ClampMagnitude(allowedPos, maxThreshold);
        transform.position = position + allowedPos;

        // Flip weapon sprite
        var mousePosToPlayer = mouseScreenPosition - position;
        spriteRenderer.flipY = mousePosToPlayer.x < 0;
        
        // TODO Switch hands - W.I.P
        var transformLocalPosition = _localTransform.position;
        if (mousePosToPlayer.x < 0) transformLocalPosition.x = position.x - maxThreshold;
        else transformLocalPosition.x = position.x + maxThreshold;
        transform.position = transformLocalPosition;
    }
}
