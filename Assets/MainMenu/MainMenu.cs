using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("NPCTest");
    }

    public void LogIn()
    {
        Debug.Log("Signing in");
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        // SceneManager.LoadScene("Quit");
        Application.Quit();
    }
}
