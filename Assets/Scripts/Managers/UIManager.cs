using UnityEngine;

public class UIManager
{
    private int _uiIndex;
    private Transform _root;

    public void Init(){}

    public GameObject Open(string uiPrefabName)
    {
        if (_root == null)
        {
            _uiIndex = Consts.UI_START_ORDER;
            _root = new GameObject($"{Defines.ManagerType.UIManager}").transform;
            Managers.Object.Create("EventSystem");
        }
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