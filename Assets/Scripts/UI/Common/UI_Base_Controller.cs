using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base_Controller : MonoBehaviour
{
    private Dictionary<string, Component> _componentDict = new();

    protected void BindButton<TEnum>() where TEnum : Enum
    {
        SetBind<Button_Effect, TEnum>();
    }
    protected void BindText<TEnum>() where TEnum : Enum
    {
        SetBind<TextMeshProUGUI, TEnum>();
    }
    protected void BindToggle<TEnum>() where TEnum : Enum
    {
        SetBind<Toggle, TEnum>();
    }
    protected void BindScrollRect<TEnum>() where TEnum : Enum
    {
        SetBind<ScrollRect, TEnum>();
    }
    protected void BindScrollBar<TEnum>() where TEnum : Enum
    {
        SetBind<Scrollbar, TEnum>();
    }
    protected void BindImage<TEnum>() where TEnum : Enum
    {
        SetBind<Image, TEnum>();
    }
    protected void BindSlider<TEnum>() where TEnum : Enum
    {
        SetBind<Slider, TEnum>();
    }
    protected void BindInputField<TEnum>() where TEnum : Enum
    {
        SetBind<TMP_InputField, TEnum>();
    }
    protected void BindDropdown<TEnum>() where TEnum : Enum
    {
        SetBind<TMP_Dropdown, TEnum>();
    }

    protected void SetBind<T, TEnum>() where T : Component where TEnum : Enum
    {
        foreach (var item in Enum.GetNames(typeof(TEnum)))
        {
            SetBind<T>(item);
        }
    }

    protected void SetBind<T>(string objName) where T : Component
    {
        var temp = transform.GetComponentsInChildren<T>(true);
        var bind = temp.FirstOrDefault((x) => x.name == objName);
        if (bind == null) return;
        _componentDict[objName] = bind;
    }
    
    protected T[] BindComponents<T>(bool includeInactive = false) where T : Component
    {
        T[] t = GetComponentsInChildren<T>(includeInactive)
        .Where((c)=>c.gameObject != gameObject).ToArray();
        return t;
    }

    protected Button_Effect GetButton(Enum enumType)
    {
        return Get<Button_Effect>(enumType);
    }

    protected TextMeshProUGUI GetText(Enum enumType)
    {
        return Get<TextMeshProUGUI>(enumType);
    }

    protected Toggle GetToggle(Enum enumType)
    {
        return Get<Toggle>(enumType);
    }

    protected ScrollRect GetScrollRect(Enum enumType)
    {
        return Get<ScrollRect>(enumType);
    }

    protected Scrollbar GetScrollbar(Enum enumType)
    {
        return Get<Scrollbar>(enumType);
    }

    protected Image GetImage(Enum enumType)
    {
        return Get<Image>(enumType);
    }

    protected Slider GetSlider(Enum enumType)
    {
        return Get<Slider>(enumType);
    }

    protected TMP_InputField GetInputField(Enum enumType)
    {
        return Get<TMP_InputField>(enumType);
    }

    protected TMP_Dropdown GetDropdown(Enum enumType)
    {
        return Get<TMP_Dropdown>(enumType);
    }
    

    protected T Get<T>(Enum enumType) where T : Component
    {
        string objName = $"{enumType}";
        T component = Get<T>(objName);
        return component;
    }

    protected T Get<T>(string objName) where T : Component
    {
        T component = _componentDict.GetValueOrDefault(objName) as T;
        return component;
    }
}
