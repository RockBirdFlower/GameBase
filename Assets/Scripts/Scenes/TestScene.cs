using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestScene : MonoBehaviour
{
    void Start()
    {
        _ = GameManager.Game;
        GameManager.Object.Create("Test");
        GameManager.Sound.PlayBgmList(new List<string>(){"TestBgm"});
        GameManager.Sound.PlaySfx("TestSfx");

        GameManager.Coroutine.StartCoroutine(CoTest(), true);

        var image = GameManager.UI.Open("TestUI").GetComponentInChild<Image>("Image_1");
        
    }

    IEnumerator CoTest()
    {
        yield return GameManager.Coroutine.GetWfs(2.5f);

        GameManager.Sound.PlaySfx("TestSfx");

    }

    
    void Update()
    {
        if (GameManager.Command.GetKey(Key.A)) Debug.Log("A");
        if(GameManager.Command.GetkeyDown(Key.S)) GameManager.Sound.PlaySfx("TestSfx");
        if (GameManager.Command.GetkeyUp(Key.D)) Debug.Log("D");
        if (GameManager.Command.GetkeyDown(Key.Escape)) GameManager.Scene.Toggle();
    }
}
