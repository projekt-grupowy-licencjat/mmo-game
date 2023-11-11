using UnityEngine;

public class Bullet : MonoBehaviour {
    [Range(1, 20)] [SerializeField] private float speed = 5f;
    [Range(1, 10)] [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
