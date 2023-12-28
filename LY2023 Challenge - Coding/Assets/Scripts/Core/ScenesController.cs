using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadOptionalScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadFirstRoom()
    {
        SceneManager.LoadScene(4);
    }
}
