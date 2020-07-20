using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // loads the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}