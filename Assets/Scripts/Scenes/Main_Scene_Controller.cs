using UnityEngine;

public class Main_Scene_Controller : Scene_Base_Controller
{
    public override void Init()
    {
        Managers.Manager.Init();
        Managers.Scene.CurrentScene = "MainScene";
        Managers.UI.Open("UI_Main_Scene");
    }
}
