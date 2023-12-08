using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour {   
    [SerializeField] private float moveSpeed;
    public NetworkVariable<Vector2> position = new NetworkVariable<Vector2>();
    private Camera _camera;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int Reversed = Animator.StringToHash("Reversed");

    private void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update() {
        if (!IsOwner) return;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        // Flip player
        Vector2 mouseScreenPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var mousePosToPlayer = mouseScreenPosition - (Vector2)transform.position;
        var transformLocalScale = transform.localScale;
        transformLocalScale.x = mousePosToPlayer.x < 0 ? -1 : 1;
        transform.localScale = transformLocalScale;
        
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
