
public class SceneManager
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}