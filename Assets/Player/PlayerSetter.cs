using Unity.Netcode;
using UnityEngine;

public class PlayerSetter : NetworkBehaviour {
    public override void OnNetworkSpawn() {
        if (IsOwner) {
            GameObject.FindWithTag("CameraTarget").GetComponent<CameraTarget>().player = transform;
        }
    }
}
