using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    private Dictionary<string, Queue<GameObject>> _prefabs = new();
    private Transform _sceneRoot;
    private Transform _managerRoot;
    public Transform SceneRoot{get{return _sceneRoot;}}

    public void Init()
    {
        _managerRoot = Managers.Manager.transform;
    }

    public void SetSceneRoot(Transform sceneRoot)
    {
        _sceneRoot = sceneRoot;
        Managers.Coroutine.SetSceneCorouine(sceneRoot);
        Managers.UI.SetSceneRoot(sceneRoot);
    }

    public GameObject Create(string prefabName, Transform parent = null, bool isPooling = false, bool isImmortal = false)
    {
        if (_sceneRoot == null && !isImmortal)
        {
            Debug.LogError("Scene Controller가 실행되지 않았습니다.");
            return null;
        }

        GameObject resource = Managers.Resource.GetPrefab(prefabName);
        if (resource == null)
        {
            Debug.LogError($"Prefab '{prefabName}'을(를) 찾을 수 없습니다.");
            return null;
        }

        if (isImmortal) parent = Managers.Object._managerRoot;

        if (parent == null) parent = Managers.Object.SceneRoot;

        if (isPooling)  return CreatePooledObject(resource, parent);

        return CreateSceneObject(resource, parent);
    }

    public T Create<T> (string prefabName, Transform parent = null, bool isPooling = false, bool isImmortal = false) where T : Component
    {
        GameObject go = Create(prefabName, parent, isPooling , isImmortal);
        if(go == null) return default;
        T t = go.GetOrAddComponent<T>();
        return t;
    }

    private GameObject CreatePooledObject(GameObject resource,Transform parent)
    {
        string prefabName = resource.name;
        if (!_prefabs.TryGetValue(prefabName, out var pool))
        {
            pool = new Queue<GameObject>();
            _prefabs[prefabName] = pool;
        }

        GameObject instance;
        if (pool.Count > 0)
        {
            instance = pool.Dequeue();
            instance.SetActive(true);
        }
        else
        {
            instance = CreateSceneObject(resource, parent);
        }

        return instance;
    }


    private GameObject CreateSceneObject(GameObject resource, Transform parent)
    {
        var instance = Object.Instantiate(resource, parent);
        instance.name = resource.name;
        return instance;
    }


    public void Destroy(GameObject prefab)
    {
        string prefabName = prefab.name;
        if (_prefabs.ContainsKey(prefabName))
        {
            prefab.SetActive(false);
            _prefabs[prefabName].Enqueue(prefab);
        }
        else
        {
            GameObject.Destroy(prefab);
        }
    }
}
