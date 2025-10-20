using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ = GameManager.Game;
        GameManager.Object.Create("Test");
        GameManager.Sound.PlayBgm("TestBgm");
        GameManager.Sound.PlaySfx("TestSfx");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
