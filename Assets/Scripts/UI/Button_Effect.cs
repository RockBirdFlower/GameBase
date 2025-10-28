using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button_Text_Color))]
public class Button_Effect : Button
{
    private TextMeshProUGUI _tmp;
    private Button_Text_Color _buttonTextColor;
    public TextMeshProUGUI Text { get { return _tmp; } }

    private Action _normal;
    private Action _highlighted;
    private Action _pressed;
    private Action _selected;
    private Action _disabled;


    protected override void Awake()
    {
        base.Awake();
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        _buttonTextColor = GetComponentInChildren<Button_Text_Color>();

        AddEvent(Defines.ButtonSelectionType.Disabled,()=>{Debug.Log("Disabled!!");});
        AddEvent(Defines.ButtonSelectionType.Highlighted,()=>{Debug.Log("Highlighted!!");});
        AddEvent(Defines.ButtonSelectionType.Normal,()=>{Debug.Log("Normal!!");});
        AddEvent(Defines.ButtonSelectionType.Pressed,()=>{Debug.Log("Press!!");});
        AddEvent(Defines.ButtonSelectionType.Selected,()=>{Debug.Log("Selected!!");});
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
            case Defines.ButtonSelectionType.Normal:
                _normal += action;
                break;
            case Defines.ButtonSelectionType.Highlighted:
                _highlighted += action;
                break;
            case Defines.ButtonSelectionType.Pressed:
                _pressed += action;
                break;
            case Defines.ButtonSelectionType.Selected:
                _selected += action;
                break;
            case Defines.ButtonSelectionType.Disabled:
                _disabled += action;
                break;
        }
    }

    public void RemoveEvent(Defines.ButtonSelectionType selectionType, Action action)
    {
        switch (selectionType)
        {
            case Defines.ButtonSelectionType.Normal:
                _normal -= action;
                break;
            case Defines.ButtonSelectionType.Highlighted:
                _highlighted -= action;
                break;
            case Defines.ButtonSelectionType.Pressed:
                _pressed -= action;
                break;
            case Defines.ButtonSelectionType.Selected:
                _selected -= action;
                break;
            case Defines.ButtonSelectionType.Disabled:
                _disabled -= action;
                break;
        }
    }

    private void ExcuteEvent(Defines.ButtonSelectionType selectionType)
    {
        Action tempAction = selectionType switch
        {
            Defines.ButtonSelectionType.Normal => _normal,
            Defines.ButtonSelectionType.Highlighted => _highlighted,
            Defines.ButtonSelectionType.Pressed => _pressed,
            Defines.ButtonSelectionType.Selected => _selected,
            Defines.ButtonSelectionType.Disabled => _disabled,
            _ => null
        };
        tempAction?.Invoke();
    }



}
