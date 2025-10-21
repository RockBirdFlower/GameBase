using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager          _game;
    private static ResourceManager      _resource;
    private static ObjectManager        _object;
    private static SoundManager         _sound;
    private static SceneManager   _scene;
    private static TimeManager          _time;
    private static CameraManager        _camera;
    private static CommandManager       _command;
    private static CoroutineManager     _coroutine;
    private static UIManager            _ui;
    
    
    


    public static GameManager Game
    {
        get
        {
            if (_game == null)
            {
                GameObject clone = new GameObject();
                clone.name = $"{Defines.ManagerType.GameManager}";
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
    
    public static SceneManager Scene
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

    public static CameraManager Camera
    {
        get
        {
            if (_camera == null)
            {
                _camera = new();
            }
            return _camera;
        }
    }

    public static CommandManager Command
    {
        get
        {
            if (_command == null)
            {
                _command = new();
            }
            return _command;
        }
    }

    public static CoroutineManager Coroutine
    {
        get
        {
            if (_coroutine == null)
            {
                _coroutine = new();
            }
            return _coroutine;
        }
    }

    public static UIManager UI
    {
        get
        {
            if (_ui == null)
            {
                _ui = new();
            }
            return _ui;
        }
    }

    
}
