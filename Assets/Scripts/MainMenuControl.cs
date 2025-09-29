using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Load the game scene
    }
    public void QuitGame()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Game is quitting..."); // Log for debugging purposes
    }
}
