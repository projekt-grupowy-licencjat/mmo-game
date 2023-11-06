using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour {   
    [SerializeField] private float moveSpeed;
    public NetworkVariable<Vector2> position = new NetworkVariable<Vector2>();
    private Camera _camera;
    private SpriteRenderer spriteRenderer;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;

    private void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update() {
        if (!IsOwner) return;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        Vector2 mouseScreenPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var mousePosToPlayer = mouseScreenPosition - (Vector2)transform.position;
        spriteRenderer.flipX = mousePosToPlayer.x < 0;
    }
    
    private void FixedUpdate() {
        if (!IsOwner) return;
        _movement.Normalize();
        _rigidBody.MovePosition(_rigidBody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
