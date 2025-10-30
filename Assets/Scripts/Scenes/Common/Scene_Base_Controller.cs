using UnityEngine;

public class Scene_Base_Controller : MonoBehaviour
{
    void Start()
    {
        Managers.Manager.Init();
        Managers.Object.SetSceneRoot(transform);
        Managers.Scene.SetTransition(true,null);
        Init();
    }

    public virtual void Init(){}
}
