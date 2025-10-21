using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExGameObject
{
    public static T[] GetComponentsInChild<T>(this GameObject go) where T : MonoBehaviour
    {
        return go.GetComponentsInChildren<T>(true);
    }

    public static T GetComponentInChild<T>(this GameObject go, string componentName) where T : MonoBehaviour
    {
        T[] array = go.GetComponentsInChildren<T>(true);

        return array.FirstOrDefault((x) => x.name == componentName);
    }
    
    public static Transform GetComponentInChildTransform(this GameObject go, string childName)
    {
        Transform[] transforms = go.GetComponentsInChildren<Transform>(true);
        return transforms.FirstOrDefault((x) => x.name == childName);
    }
}