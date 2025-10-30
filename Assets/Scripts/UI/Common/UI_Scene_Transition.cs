using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class UI_Scene_Transition : UI_Base_Controller
{
    [SerializeField]private RectTransform[] _rects;
    [SerializeField]private RectTransform[] _reverse;

    private float _duration = 0.4f;
 
    private void Start()
    {
        _rects = BindComponents<RectTransform>();
        _reverse = _rects.Reverse().ToArray();
    }

    public void SetTransition(bool isOpen, Action action)
    {
        StartCoroutine(CoTransition(isOpen,action));
    }

    private IEnumerator CoTransition(bool isOpen ,Action action)
    {
        Vector2 pos = (isOpen) ? Vector2.right * 1920 : Vector2.zero;
        
        yield return null;
        RectTransform[] rects = (isOpen)? _reverse : _rects;
        
        foreach (var rect in rects)
        {
             yield return rect.DOAnchorPos(pos, _duration)
                .SetEase(Ease.InExpo)
                .WaitForCompletion();
        }


        yield return DOTween.Sequence().AppendInterval(_duration).WaitForCompletion();

        action?.Invoke();
    }
}