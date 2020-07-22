using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // loads the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}