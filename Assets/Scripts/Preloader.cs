using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    // starts the first scene after awake runs for all the good stuff
    private void Start()
    {
        SceneManager.LoadScene(1);
    }
}