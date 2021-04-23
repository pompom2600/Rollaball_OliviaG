using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}