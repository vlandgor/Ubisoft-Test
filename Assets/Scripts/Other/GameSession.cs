using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSession
{
    public static void StartGame()
    {
        GameScene.CreateScene();
    }

    public static void QuitGame()
    {
        GameScene.ResetScene();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void SaveGame()
    {
        SaveSystem.SaveScene(GameScene.GetPlanetsList());
    }

    public static void LoadGame()
    {
        GameScene.LoadScene(SaveSystem.LoadScene());
    }
}
