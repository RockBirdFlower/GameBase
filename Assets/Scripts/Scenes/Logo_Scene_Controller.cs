using System.Collections;
using UnityEngine;

public class Logo_Scene_Controller : Scene_Base_Controller
{
    public override void Init()
    {
        Managers.Manager.Init();
        Managers.Scene.CurrentScene = "LogoScene";
        Managers.UI.Open("UI_Logo_Scene");
        StartCoroutine(CoNextScene());
    }

    private IEnumerator CoNextScene()
    {
        yield return Managers.Coroutine.GetWfs(2f);
        Managers.Scene.SetScene("TitleScene");
    }
}
