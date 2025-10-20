using UnityEngine.SceneManagement;

public class SceneChangeManager
{
    private string _currentScene;
    public string CurrentScene
    {
        get
        {
            return _currentScene;
        }
    }

    public void SetScene(string sceneName)
    {
        _currentScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
}