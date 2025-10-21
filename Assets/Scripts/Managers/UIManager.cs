using UnityEngine;

public class UIManager
{
    private int _uiIndex;
    private Transform _root;

    public GameObject Open(string uiPrefabName)
    {
        if (_root == null)
        {
            _uiIndex = Consts.UI_START_ORDER;
            _root = new GameObject($"{Defines.ManagerType.UIManager}").transform;
            GameManager.Object.Create("EventSystem");
        }
        GameObject prefab = GameManager.Object.Create(uiPrefabName);
        prefab.GetComponentInChildren<Canvas>().sortingOrder = _uiIndex;
        _uiIndex++;
        return prefab;
    }

    public void Close(GameObject uiPrefab)
    {
        _uiIndex--;
        GameManager.Object.Destroy(uiPrefab);
    }
}