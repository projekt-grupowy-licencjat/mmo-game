using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour {   
    [SerializeField] private float moveSpeed;
    public NetworkVariable<Vector2> position = new NetworkVariable<Vector2>();
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;

    private void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update() {
        if (!IsOwner) return;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate() {
        if (!IsOwner) return;
        _movement.Normalize();
        _rigidBody.MovePosition(_rigidBody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
