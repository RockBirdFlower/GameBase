using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestScene : MonoBehaviour
{
    void Start()
    {
        _ = Managers.Manager;
        Managers.Object.Create("Test");
        Managers.Sound.PlayBgmList(new List<string>(){"TestBgm"});
        Managers.Sound.PlaySfx("TestSfx");

        Managers.Coroutine.StartCoroutine(CoTest(), true);

        var image = Managers.UI.Open("TestUI").GetComponentInChild<Image>("Image_1");
        
    }

    IEnumerator CoTest()
    {
        yield return Managers.Coroutine.GetWfs(2.5f);

        Managers.Sound.PlaySfx("TestSfx");

    }

    
    void Update()
    {
        if (Managers.Command.GetKey(Key.A)) Debug.Log("A");
        if(Managers.Command.GetkeyDown(Key.S)) Managers.Sound.PlaySfx("TestSfx");
        if (Managers.Command.GetkeyUp(Key.D)) Debug.Log("D");
        if (Managers.Command.GetkeyDown(Key.Escape)) Managers.Scene.Toggle();
    }
}
