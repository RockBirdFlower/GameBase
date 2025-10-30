using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class Edit_Create
{
    [MenuItem("GameObject/UI/Button_Effect")]
    public static void Create_Button_Effect(MenuCommand menuCommand)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/UI/Common/Button_Effect.prefab");
        if(prefab == null) return;
        
        GameObject parent = Selection.activeGameObject;

        if(menuCommand.context as GameObject != null)
            parent = menuCommand.context as GameObject;
        
        GameObject clone = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        PrefabUtility.UnpackPrefabInstance(clone, PrefabUnpackMode.Completely,InteractionMode.AutomatedAction);

        if(parent != null)
            GameObjectUtility.SetParentAndAlign(clone, parent);
        else
            Debug.LogWarning("No GameObject Selected.");
        
        Undo.RegisterChildrenOrderUndo(clone, "Create Advanced Button Prefab");

        Selection.activeGameObject = clone;
    }
}