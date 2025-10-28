using UnityEngine;
using UnityEngine.InputSystem;

public class CommandManager
{

    public void Init(){}

    
    public bool GetKey(Key key) // 키보드 눌러질때 지속
    {
        if (Keyboard.current == null) return false;

        return Keyboard.current[key].isPressed;
    }
    public bool GetkeyDown(Key key) // 키보드 누를때 한 번
    {
        if (Keyboard.current == null) return false;

        return Keyboard.current[key].wasPressedThisFrame;
    }
    public bool GetkeyUp(Key key) // 키보드 올라올때 한 번
    {
        if (Keyboard.current == null) return false;

        return Keyboard.current[key].wasReleasedThisFrame;
    }

    public bool GetMouse(int mouseButton)
    {
        if (Mouse.current == null) return false;

        switch (mouseButton)
        {
            case 0:
                return Mouse.current.leftButton.isPressed;
            case 1:
                return Mouse.current.rightButton.isPressed;
            case 2:
                return Mouse.current.middleButton.isPressed;
            default:
                return false;
        }
    }

    public bool GetMouseDown(int mouseButton)
    {
        if (Mouse.current == null) return false;

        switch (mouseButton)
        {
            case 0:
                return Mouse.current.leftButton.wasPressedThisFrame;
            case 1:
                return Mouse.current.rightButton.wasPressedThisFrame;
            case 2:
                return Mouse.current.middleButton.wasPressedThisFrame;
            default:
                return false;
        }
    }

    public bool GetMouseUp(int mouseButton)
    {
        if (Mouse.current == null) return false;

        switch (mouseButton)
        {
            case 0:
                return Mouse.current.leftButton.wasReleasedThisFrame;
            case 1:
                return Mouse.current.rightButton.wasReleasedThisFrame;
            case 2:
                return Mouse.current.middleButton.wasReleasedThisFrame;
            default:
                return false;
        }
    }

    public Vector2 GetMousePosition()
    {
        if (Mouse.current == null) return Vector2.zero;

        return Mouse.current.position.ReadValue();
    }

    public Vector2 GetMouseWorldPosition()
    {
        Camera cam = Managers.Camera.MainCamera;
        if (Mouse.current == null) return Vector2.zero;

        Vector2 wolrdPosition = cam.ScreenToWorldPoint(GetMousePosition());
        return wolrdPosition;
    }
}