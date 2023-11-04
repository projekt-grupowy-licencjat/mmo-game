using UnityEngine;

public class CameraTarget : MonoBehaviour {
    [SerializeField] private new Camera camera;
    [SerializeField] public Transform player;
    [SerializeField] private float threshold;

    private void Update() {
        if (!player) return;
        var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var position = player.position;
        var targetPos = (position + mousePosition) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + position.x, threshold + position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + position.y, threshold + position.y);

        transform.position = targetPos;
    }
}
