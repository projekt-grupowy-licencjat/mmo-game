using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultiplayerMenu : MonoBehaviour
{
    public TMP_InputField input;
    
    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
    }
 
    private void OnDestroy()
    {
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        }
    }
    
    public void SubmitInput()
    { 
        var inputValue = input.text;
        Debug.Log("Podane ip to: " + inputValue +" /n");
        var split = inputValue.Split(":");
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
            split[0],
            (ushort) int.Parse(split[1])
        );
        NetworkManager.Singleton.StartClient();
    }

    public void ClearInput()
    {
        input.text = "";
    }

    public void HostServer()
    {
            Debug.Log("hosting");
            NetworkManager.Singleton.StartHost();
    }
    
    private void HandleServerStarted()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            var status = NetworkManager.Singleton.SceneManager.LoadScene("Maciek", LoadSceneMode.Single);
 
            if (status != SceneEventProgressStatus.Started)
            {
                Debug.LogWarning($"Failed to load Hub with a {nameof(SceneEventProgressStatus)}: {status}");
            }
        } 
        else if (NetworkManager.Singleton.IsClient)
        {
            var status = NetworkManager.Singleton.SceneManager.LoadScene("Maciek", LoadSceneMode.Single);
 
            if (status != SceneEventProgressStatus.Started)
            {
                Debug.LogWarning($"Failed to load Hub with a {nameof(SceneEventProgressStatus)}: {status}");
            }
        }
    }
}
