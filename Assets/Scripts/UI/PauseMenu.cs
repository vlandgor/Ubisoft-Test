using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        GameSession.PauseGame();
    }

    public void ResumeGame()
    {
        GameSession.ResumeGame();
    }

    public void SaveGame()
    {
        GameSession.SaveGame();
    }

    public void SaveAndQuitGame()
    {
        GameSession.SaveGame();
        GameSession.QuitGame();
        GameSession.ResumeGame();
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
