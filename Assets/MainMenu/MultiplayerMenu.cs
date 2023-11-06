using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


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
    }

}
