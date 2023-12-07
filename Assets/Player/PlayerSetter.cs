using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetter : NetworkBehaviour
{
    [SerializeField] private float retryTime = 1f;
    
    private WeaponRotation _weaponRotation;
    private PlayerController _playerController;
    
    public void Start() {
        if (!IsOwner) return;
        _weaponRotation = transform.GetChild(0).GetComponent<WeaponRotation>();
        _playerController = GetComponent<PlayerController>();
        var coroutine = AssignValues();
        var uiCoroutine = AssignUI();
        StartCoroutine(coroutine);
        StartCoroutine(uiCoroutine);
    }
    

    private IEnumerator AssignValues()
    {
        bool succeeded = false;

        while (!succeeded)
        {
            CameraTarget cameraTarget = null;
            Camera mainCamera = null;
            try
            {
                cameraTarget = GameObject.FindWithTag("CameraTarget")
                    ?.GetComponent<CameraTarget>();
                mainCamera = GameObject.FindWithTag("MainCamera")
                    ?.GetComponent<Camera>();
            }
            catch (NullReferenceException)
            {
                Debug.Log("CameraTarget not found");
            }

            if (cameraTarget != null && mainCamera != null)
            {
                cameraTarget.player = transform;
                _weaponRotation.cameraRef = mainCamera;
                _playerController.cameraRef = mainCamera;
                succeeded = true;
            }
            yield return new WaitForSeconds(retryTime);
        }
    }

    private IEnumerator AssignUI()
    {
        bool succeeded = false;

        while (!succeeded)
        {
            UIManager.UIManager uiManager = null;
            try
            {
                uiManager = GameObject.FindWithTag("UIManager")
                    .GetComponent<UIManager.UIManager>();
            }
            catch (NullReferenceException)
            {
                Debug.Log("UI not found");
            }

            if (uiManager != null)
            {
                uiManager.playerController = GetComponent<PlayerController>();
                uiManager.weaponRotation =
                    transform.GetChild(0).GetComponent<WeaponRotation>();
                uiManager.cameraTarget = GameObject.FindWithTag("CameraTarget")
                    .GetComponent<CameraTarget>();
                succeeded = true;
            }
            yield return new WaitForSeconds(retryTime);
        }
    }
}
