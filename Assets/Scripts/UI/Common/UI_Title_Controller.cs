using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UI_Title_Controller : UI_Base_Controller
{
    enum Texts
    {
        Text_PleaseInput,
    }
    private void Start()
    {
        BindText<Texts>();

        GetText(Texts.Text_PleaseInput).DOFade(0,1).SetLoops(-1,LoopType.Yoyo);

        StartCoroutine(CoTitle());
    }

    private IEnumerator CoTitle()
    {
        yield return Managers.Coroutine.GetWfs(1f);

        while (true)
        {
            yield return null;
            if(Managers.Command.GetAnykeyDown())
            {
                Managers.Scene.SetScene("MainScene");
                break;
            }
        }
    }
    
}
