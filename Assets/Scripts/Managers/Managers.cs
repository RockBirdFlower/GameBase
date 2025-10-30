using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers             _manager;
    private static GameManager          _game;
    private static ResourceManager      _resource;
    private static ObjectManager        _object;
    private static SoundManager         _sound;
    private static SceneManager         _scene;
    private static TimeManager          _time;
    private static CameraManager        _camera;
    private static CommandManager       _command;
    private static CoroutineManager     _coroutine;
    private static UIManager            _ui;
    

    public static Managers Manager
    {
        get
        {
            if (_manager == null)
            {
                GameObject clone = new GameObject();
                clone.name = $"{Defines.ManagerType.Manager}";
                _manager = clone.AddComponent<Managers>();
                DontDestroyOnLoad(_manager);
                _manager.Init();
            }

            return _manager;
        }
    }

    public static GameManager Game
    {
        get
        {
            if (_game == null)
            {
                _game = new();
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

    public void Init()
    {
        if(Game.IsInit) return;
        Game.Init();
        Resource.Init();
        Object.Init();
        Sound.Init();
        Scene.Init();
        Time.Init();
        Camera.Init();
        Command.Init();
        Coroutine.Init();
        UI.Init();
    }

    
}
