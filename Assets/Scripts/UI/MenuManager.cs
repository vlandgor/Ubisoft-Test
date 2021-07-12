using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.isNewScene = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.isNewScene = false;
    }
}
