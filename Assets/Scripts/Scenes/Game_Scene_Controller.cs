using UnityEngine;

public class Game_Scene_Controller : Scene_Base_Controller
{
    public override void Init()
    {
        Managers.Scene.CurrentScene = "GameScene";
    }
}
