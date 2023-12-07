using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetter : NetworkBehaviour
{
    [SerializeField] private float retryTime = 1f;
    
    public void Start() {
        if (!IsOwner) return;
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
            try
            {
                cameraTarget = GameObject.FindWithTag("CameraTarget")
                    ?.GetComponent<CameraTarget>();
            }
            catch (NullReferenceException e)
            {
                Debug.Log("CameraTarget not found");
            }

            if (cameraTarget != null)
            {
                cameraTarget.player = transform;
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
            catch (NullReferenceException e)
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
