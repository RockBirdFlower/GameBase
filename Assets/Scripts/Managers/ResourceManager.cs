using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceManager 
{
    private Dictionary<string, GameObject> _prefabs = new();
    private Dictionary<string, AudioClip> _clips = new();
    private Dictionary<string, Sprite> _sprites = new();
    public void Init()
    {
        _prefabs = Resources.LoadAll<GameObject>("Prefabs/").ToDictionary((x) => x.name, (x) => x);
        _clips = Resources.LoadAll<AudioClip>("Sounds/").ToDictionary((x) => x.name, (x) => x);
        _sprites = Resources.LoadAll<Sprite>("Sprites/").ToDictionary((x) => x.name, (x) => x);
    }

    public GameObject GetPrefab(string prefabName)
    {
        GameObject prefab = null;
        prefab = _prefabs.GetValueOrDefault(prefabName);

        return prefab;
    }

    public AudioClip GetClip(string clipName)
    {
        AudioClip clip = null;
        clip = _clips.GetValueOrDefault(clipName);
        return clip;
    }

    public Sprite GetSprite(string spriteName)
    {
        Sprite sprite = null;
        sprite = _sprites.GetValueOrDefault(spriteName);
        return sprite;
    }

    
}
