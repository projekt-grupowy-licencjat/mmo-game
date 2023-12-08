using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetter : NetworkBehaviour {
    public override void OnNetworkSpawn() {
        if (!IsOwner) return;
        GameObject.FindWithTag("CameraTarget").GetComponent<CameraTarget>().player = transform;
        GameObject.FindWithTag("UIManager").GetComponent<UIManager.UIManager>().playerController = GetComponent<PlayerController>();
        GameObject.FindWithTag("UIManager").GetComponent<UIManager.UIManager>().weaponRotation = transform.GetChild(0).GetComponent<WeaponRotation>();
        GameObject.FindWithTag("UIManager").GetComponent<UIManager.UIManager>().cameraTarget = GameObject.FindWithTag("CameraTarget").GetComponent<CameraTarget>();
    }
}
