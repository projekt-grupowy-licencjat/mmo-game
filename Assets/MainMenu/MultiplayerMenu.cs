using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultiplayerMenu : MonoBehaviour
{
    public TMP_InputField input;
    
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
            SceneManager.LoadScene("Hub");
    }

}
