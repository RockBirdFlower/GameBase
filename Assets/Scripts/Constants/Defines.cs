public static class Defines
{
    public enum ManagerType
    {
        Manager,
        GameManager,
        ResourceManager,
        ObjectManager,
        SoundManager,
        SceneManager,
        TimeManager,
        CameraManager,
        CommandManager,
        CoroutineManager,
        UIManager,
    }

    public enum SceneType
    {
        NoneScene,
        TestScene,
        TitleScene,
        MainScene,
        GameScene,
    }

    public enum SoundType
    {
        Bgm,
        Sfx,
    }

    public enum ButtonSelectionType
    {
        Normal,
        Highlighted,
        Pressed,
        Selected,
        Disabled,
    }
}