using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button_Text_Color))]
public class Button_Effect : Button
{
    private TextMeshProUGUI _tmp;
    private Button_Text_Color _buttonTextColor;
    
    private Action _highlighted;
    private Action _clicked;
    private Action _pressed;
    private Action _selectEnableded;
    private Action _disabled;
    private Action _selectDisabled;

    private Coroutine _coPress;

    private float _pressTime;

    private bool _isButtonDown;
    private bool _isSelectEnabled;


    public TextMeshProUGUI Text { get { return _tmp; } }
    public Image Image  { get { return image; } }
    public RectTransform RectTransform  { get { return Image.rectTransform; } }


    protected override void Awake()
    {
        base.Awake();
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        _buttonTextColor = GetComponentInChildren<Button_Text_Color>();
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        if (gameObject.activeInHierarchy == false || _tmp == null) return;
        var colors = _buttonTextColor.colors;
        Color color = state switch
        {
            SelectionState.Normal => colors.normalColor,
            SelectionState.Highlighted => colors.highlightedColor,
            SelectionState.Pressed => colors.pressedColor,
            SelectionState.Selected => colors.selectedColor,
            SelectionState.Disabled => colors.disabledColor,
            _ => Color.white
        };

        _tmp.color = color;
        ExcuteEvent((Defines.ButtonSelectionType)(int)state);
    }

    public void AddEvent(Defines.ButtonSelectionType selectionType, Action action)
    {
        switch (selectionType)
        {
            case Defines.ButtonSelectionType.Clicked:
                _clicked += action;
                break;
            case Defines.ButtonSelectionType.Highlighted:
                _highlighted += action;
                break;
            case Defines.ButtonSelectionType.Pressed:
                _pressed += action;
                break;
            case Defines.ButtonSelectionType.SelectEnabled:
                _selectEnableded += action;
                break;
            case Defines.ButtonSelectionType.Disabled:
                _disabled += action;
                break;
            case Defines.ButtonSelectionType.SelectDisabled:
                _selectDisabled += action;
                break;
        }
    }

    public void RemoveEvent(Defines.ButtonSelectionType selectionType, Action action)
    {
        switch (selectionType)
        {
            case Defines.ButtonSelectionType.Clicked:
                _clicked -= action;
                break;
            case Defines.ButtonSelectionType.Highlighted:
                _highlighted -= action;
                break;
            case Defines.ButtonSelectionType.Pressed:
                _pressed -= action;
                break;
            case Defines.ButtonSelectionType.SelectEnabled:
                _selectEnableded -= action;
                break;
            case Defines.ButtonSelectionType.Disabled:
                _disabled -= action;
                break;
            case Defines.ButtonSelectionType.SelectDisabled:
                _selectDisabled -= action;
                break;
        }
    }

    public void RemoveAllEvent(Defines.ButtonSelectionType selectionType)
    {
       switch (selectionType)
        {
            case Defines.ButtonSelectionType.Clicked:
                _clicked = null;
                break;
            case Defines.ButtonSelectionType.Highlighted:
                _highlighted = null;
                break;
            case Defines.ButtonSelectionType.Pressed:
                _pressed = null;
                break;
            case Defines.ButtonSelectionType.SelectEnabled:
                _selectEnableded = null;
                break;
            case Defines.ButtonSelectionType.Disabled:
                _disabled = null;
                break;
            case Defines.ButtonSelectionType.SelectDisabled:
                _selectDisabled = null;
                break;
        }
    }

    private void ExcuteEvent(Defines.ButtonSelectionType selectionType)
    {
        switch (selectionType)
        {
            case Defines.ButtonSelectionType.Clicked: 
                OnSelectDisabled();
                break;
            case Defines.ButtonSelectionType.Highlighted: 
                _highlighted?.Invoke();
                break;
            case Defines.ButtonSelectionType.Pressed:
                break;
            case Defines.ButtonSelectionType.SelectEnabled: 
                _isSelectEnabled = true;
                _selectEnableded?.Invoke();
                break;
            case Defines.ButtonSelectionType.Disabled: 
                _disabled?.Invoke();
                break;
            default: break;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _isButtonDown = true;
        if(_coPress != null) StopCoroutine(_coPress);
        _coPress = StartCoroutine(CoPressCheck());
    } 

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _isButtonDown = false;
    }

    private void OnSelectDisabled()
    {
        if(_isSelectEnabled)
        {
            _selectDisabled?.Invoke();
            _isSelectEnabled = false;
        }
    }


    private IEnumerator CoPressCheck()
    {
        _pressTime = Time.time;
        while (_isButtonDown)
        {
            yield return null;
            if(Time.time - _pressTime >= Consts.PRESS_RATE)
            {
                yield return Managers.Coroutine.GetWfs(Consts.PRESS_INTERVAL);
                _pressed?.Invoke();
            }
        }

        if(Time.time - _pressTime <= Consts.CLICK_RATE) _clicked?.Invoke();

    }




}
