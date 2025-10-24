
using System.Collections;
using UnityEngine;

public class SceneManager
{
    private string _currentScene;
    private SceneTransition _transition;

    public string CurrentScene
    {
        get
        {
            return _currentScene;
        }
    }

    private SceneTransition Transition
    {
        get
        {
            if (_transition == null)
            {
                _transition = new();
                _transition.transitionGo = GameManager.Object.Create("SceneTransition");
                _transition.rect = _transition.transitionGo.GetComponentInChildTransform("TransitionRect") as RectTransform;
            }
            return _transition;
        }
    }

    public void SetScene(string sceneName, float duration = 1f)
    {
        _currentScene = sceneName;
        GameManager.Coroutine.StartCoroutine(CoSetScene(duration), true);
    }

    private IEnumerator CoSetScene(float duration)
    {
        yield return Transition.CoClose();
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_currentScene);
        yield return Transition.CoOpen();
    }

    public void Toggle()
    {
        if (Transition.IsOpen == false) Open();
        else Close();
    }

    public void Open()
    {
        GameManager.Coroutine.StartCoroutine(Transition.CoOpen(), true);
    }
    
    public void Close()
    {
        GameManager.Coroutine.StartCoroutine(Transition.CoClose(), true);
    }
}

public class SceneTransition
{
    public GameObject transitionGo;
    public RectTransform rect;
    public Vector2 openPosition = Vector2.right * 1920;
    public Vector2 closePosition = Vector2.zero;
    public bool IsOpen { get; private set; }

    public IEnumerator CoOpen()
    {
        rect.anchoredPosition = closePosition;
        transitionGo.SetActive(true);
        IsOpen = true;
        float value = 0f;
        while (value < 1)
        {
            value += Time.deltaTime;
            rect.anchoredPosition = Vector2.Lerp(closePosition, openPosition, value);
            yield return null;
        }
        transitionGo.SetActive(false);
    }

    public IEnumerator CoClose()
    {
        rect.anchoredPosition = openPosition;
        transitionGo.SetActive(true);
        IsOpen = false;
        float value = 0f;
        while (value < 1)
        {
            value += Time.deltaTime;
            rect.anchoredPosition = Vector2.Lerp(openPosition, closePosition, value);
            yield return null;
        }
    }
}