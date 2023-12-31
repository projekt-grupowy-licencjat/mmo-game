using UnityEngine;

public class CameraTarget : MonoBehaviour {
    [SerializeField] private Camera cameraRef;
    [SerializeField] public Transform player;
    [SerializeField] private float threshold;
    public UIManager.UIManager uiManager;
    
    private void Update() {
        if (!player) return;
        if (!cameraRef) return;
        if (uiManager.isPaused) return;
        var mousePosition = cameraRef.ScreenToWorldPoint(Input.mousePosition);
        var position = player.position;
        var targetPos = (position + mousePosition) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + position.x, threshold + position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + position.y, threshold + position.y);

        transform.position = targetPos;
    }
}
