using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponRotation : NetworkBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Camera cameraRef;
    private Transform _localTransform;
    private Vector3 _localScale;
    [SerializeField] private float maxThreshold;

    private void Start() {
        if (!IsOwner) return;
        _localTransform = transform;
        _localScale = _localTransform.localScale;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (!IsOwner) return;
        if (!cameraRef) return;
        _localTransform = transform;
        Vector2 mouseScreenPosition = cameraRef.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = _localTransform.parent.gameObject.transform.position;
        
        // TODO Rotate around player - W.I.P
        var allowedPos = mouseScreenPosition - position;
        allowedPos = Vector3.ClampMagnitude(allowedPos, maxThreshold);
        _localTransform.position = position + allowedPos;

        // Flip weapon sprite
        var mousePosToPlayer = mouseScreenPosition - position;
        var transformLocalScale = _localTransform.localScale;
        transformLocalScale.x = mousePosToPlayer.x < 0 ? -_localScale.x : _localScale.x;
        transformLocalScale.y = mousePosToPlayer.x < 0 ? -_localScale.y : _localScale.y;
        _localTransform.localScale = transformLocalScale;
        // spriteRenderer.flipY = mousePosToPlayer.x < 0;
        
        // TODO Switch hands - W.I.P
        var transformLocalPosition = _localTransform.position;
        if (mousePosToPlayer.x < 0) transformLocalPosition.x = position.x - maxThreshold;
        else transformLocalPosition.x = position.x + maxThreshold;
        _localTransform.position = transformLocalPosition;
        
        // Rotate weapon
        _localTransform.right =(mouseScreenPosition - (Vector2)_localTransform.position).normalized;
    }

}
