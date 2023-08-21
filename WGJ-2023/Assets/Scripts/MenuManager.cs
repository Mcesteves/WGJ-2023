using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string Game;
    public string Settings;
    public string Credits;

    private void Start()
    {
        AudioManager.instance.Play("menu");
    }
    public void StartGame ()
    {   
        SceneManager.LoadScene(Game);
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene(Settings);
    }
  
    public void OpenCredits()
    {
        SceneManager.LoadScene(Credits);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("saindo");
    }
}
