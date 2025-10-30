using UnityEngine;

public class Title_Scene_Controller : Scene_Base_Controller
{

    public override void Init()
    {
        Managers.Manager.Init();
        Managers.Scene.CurrentScene = "TitleScene";
        Managers.UI.Open("UI_Title_Scene");
    }
}
