using System.Collections;
using UnityEngine;


public class CameraShake : MonoBehaviour {
    [SerializeField] private AnimationCurve recoilCurve;
    [SerializeField] private float recoilDuration;
    
    public IEnumerator Shake() {
        var timer = 0f;
        while (timer < recoilDuration) {
            var originalPosition = transform.localPosition;
            var recoilAmount = recoilCurve.Evaluate(timer / recoilDuration);
            transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * recoilAmount;
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
