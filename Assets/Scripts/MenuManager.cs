using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void Paki()
    {
        SceneManager.LoadScene("Tienda");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
