using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour {   
    [SerializeField] private float moveSpeed;
    public Camera cameraRef;
    private Animator _animator;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int Reversed = Animator.StringToHash("Reversed");

    private void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update() {
        if (!IsOwner) return;
        if (!cameraRef) return;
        var transform1 = transform;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        // Flip player
        Vector2 mouseScreenPosition = cameraRef.ScreenToWorldPoint(Input.mousePosition);
        var mousePosToPlayer = mouseScreenPosition - (Vector2)transform1.position;
        var transformLocalScale = transform1.localScale;
        transformLocalScale.x = mousePosToPlayer.x < 0 ? -1 : 1;
        transform1.localScale = transformLocalScale;
        
        // Animator
        _animator.SetBool(IsRunning, _movement != Vector2.zero);
        _animator.SetBool(Reversed, _movement.x != 0f && _movement.x * mousePosToPlayer.x < 0f);
        
    }
    
    private void FixedUpdate() {
        if (!IsOwner) return;
        _movement.Normalize();
        _rigidBody.MovePosition(_rigidBody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
