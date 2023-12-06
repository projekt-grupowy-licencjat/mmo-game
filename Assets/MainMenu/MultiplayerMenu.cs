using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
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
            var status = NetworkManager.Singleton.SceneManager.LoadScene("Hub", LoadSceneMode.Single);
 
            if (status != SceneEventProgressStatus.Started)
            {
                Debug.LogWarning($"Failed to load Hub with a {nameof(SceneEventProgressStatus)}: {status}");
            }
        }
    }
}
