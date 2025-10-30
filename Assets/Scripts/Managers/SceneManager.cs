
using System;
using System.Collections;
using UnityEngine;

public class SceneManager
{
    private string _currentScene;
    private UI_Scene_Transition _transition;

    public string CurrentScene{get{return _currentScene;}set{_currentScene = value;}}

    public void Init()
    {
        _transition = Managers.Object.Create<UI_Scene_Transition>("UI_Scene_Transition",isImmortal:true);
    }

    public void SetTransition(bool isOpen, Action action)
    {
        _transition.SetTransition(isOpen, action);
    }


    public void SetScene(string sceneName, bool isOpen = false, float duration = 1f, bool isIgnore = false)
    {
        if(_currentScene == sceneName && isIgnore == false) return;
        _currentScene = sceneName;
        _transition.SetTransition(isOpen ,()=>UnityEngine.SceneManagement.SceneManager.LoadScene(_currentScene));
    }
}