using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager          _game;
    private static ResourceManager      _resource;
    private static ObjectManager        _object;
    private static SoundManager         _sound;
    private static SceneChangeManager   _scene;
    private static TimeManager          _time;


    public static GameManager Game
    {
        get
        {
            if (_game == null)
            {
                GameObject clone = new GameObject();
                clone.name = "GameManager";
                _game = clone.AddComponent<GameManager>();
                DontDestroyOnLoad(_game);
            }

            return _game;
        }
    }
    public static ResourceManager Resource
    {
        get
        {
            if (_resource == null)
            {
                _resource = new();
                _resource.Setup();
            }
            return _resource;
        }
    }
    public static ObjectManager Object
    {
        get
        {
            if (_object == null)
            {
                _object = new();
            }
            return _object;
        }
    }
    public static SoundManager Sound
    {
        get
        {
            if (_sound == null)
            {
                _sound = new();
            }
            return _sound;
        }
    }
    
    public static SceneChangeManager Scene
    {
        get
        {
            if (_scene == null)
            {
                _scene = new();
            }
            return _scene;
        }
    }

    public static TimeManager Time
    {
        get
        {
            if (_time == null)
            {
                _time = new();
            }
            return _time;
        }
    }
}
