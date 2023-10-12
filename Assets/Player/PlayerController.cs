using UnityEngine;

public class PlayerController : MonoBehaviour {   
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rigidBody;

    private Vector2 _movement;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update() {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate() {
        _movement.Normalize();
        rigidBody.MovePosition(rigidBody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
