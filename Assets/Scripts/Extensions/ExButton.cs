using System;

public static class ExButton
{
    public static void EventAdd(this Button_Effect button, Defines.ButtonSelectionType selectionType, Action action)
    {
        button.AddEvent(selectionType, action);
    }
    
    public static void EventRemove(this Button_Effect button , Defines.ButtonSelectionType selectionType, Action action)
    {
        button.RemoveEvent(selectionType, action.Invoke);
    }

    public static void EventRemoveAll(this Button_Effect button, Defines.ButtonSelectionType selectionType)
    {
        button.RemoveAllEvent(selectionType);
    }
}