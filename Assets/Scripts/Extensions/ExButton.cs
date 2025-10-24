using System;
using UnityEngine.UI;

public static class ExButton
{

    public static void OnButtonClick(this Button button, Action action)
    {
        button.onClick.AddListener(action.Invoke);
    }
    
    public static void RemoveListeners(this Button button, Action action)
    {
        button.onClick.RemoveListener(action.Invoke);
    }

    public static void RemoveAllListeners(this Button button)
    {
        button.onClick.RemoveAllListeners();
    }
}