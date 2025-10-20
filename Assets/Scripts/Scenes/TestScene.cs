using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ = GameManager.Game;
        GameManager.Object.Create("Test");
        GameManager.Sound.PlayBgm("TestBgm");
        GameManager.Sound.PlaySfx("TestSfx");

        GameManager.Coroutine.StartCoroutine(CoTest(),true);

    }

    IEnumerator CoTest()
    {
        yield return GameManager.Coroutine.GetWfs(2.5f);

        GameManager.Sound.PlaySfx("TestSfx");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Command.GetKey(Key.A)) Debug.Log("A");
        if(GameManager.Command.GetkeyDown(Key.S)) Debug.Log("S");
        if(GameManager.Command.GetkeyUp(Key.D)) Debug.Log("D");
    }
}
