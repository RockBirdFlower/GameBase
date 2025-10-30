using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    private int _uiIndex;
    private Transform _sceneRoot;

    public void Init()
    {
        var enventSystem = GameObject.FindObjectsByType<EventSystem>(FindObjectsSortMode.None);
        for (int i = 0; i < enventSystem.Length; i++)
        {
            GameObject.Destroy(enventSystem[i]);
        }

        Managers.Object.Create("EventSystem", isImmortal:true);
    }

    public void SetSceneRoot(Transform root)
    {
        _sceneRoot = root;
    }

    public GameObject Open(string uiPrefabName)
    {
        GameObject prefab = Managers.Object.Create(uiPrefabName);
        prefab.GetComponentInChildren<Canvas>().sortingOrder = _uiIndex;
        _uiIndex++;
        return prefab;
    }

    public void Close(GameObject uiPrefab)
    {
        _uiIndex--;
        Managers.Object.Destroy(uiPrefab);
    }
}