using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    private Dictionary<string, Queue<GameObject>> _prefabs = new();
    private Transform _root;
    public GameObject Create(string prefabName, bool isPooling = false)
    {
        if(_root == null)
        {
            _root = new GameObject("ObjectManager").transform;
        }
        GameObject resource = GameManager.Resource.GetPrefab(prefabName);
        GameObject prefab = null;
        if (resource == null) return prefab;
        if (isPooling)
        {
            if (_prefabs.ContainsKey(prefabName))
            {
                if (_prefabs[prefabName].Count > 0)
                {
                    prefab = _prefabs[prefabName].Dequeue();
                }
                else
                {
                    prefab = GameObject.Instantiate(resource, _root);
                    prefab.name = prefabName;
                }
            }
            else
            {
                _prefabs[prefabName] = new();
                prefab = GameObject.Instantiate(resource, _root);
                prefab.name = prefabName;
            }
        }
        else
        {
            prefab = GameObject.Instantiate(resource, _root, false);
            prefab.name = prefabName;
        }
        return prefab;
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
