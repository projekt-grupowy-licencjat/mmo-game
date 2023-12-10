using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour {
    [Range(1, 20)] [SerializeField] private float speed = 5f;
    [Range(1, 10)] [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (IsServer)
        {
            Destroy(gameObject, lifeTime);
        }
        else
        {
            DestroyBecauseLifetimeServerRPC();
        }
        
    }

    private void FixedUpdate() {
        _rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (IsHost) Destroy(gameObject);
        else DestroyBecauseTriggerServerRPC();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void DestroyBecauseTriggerServerRPC()
    {
        gameObject.GetComponent<NetworkObject>().Despawn();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void DestroyBecauseLifetimeServerRPC()
    {
        Destroy(gameObject, lifeTime);
    }
}
