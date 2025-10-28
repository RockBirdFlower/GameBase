using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineManager
{
    private Dictionary<float, WaitForSeconds> _wfs = new();
    private MonoBehaviour dondestroy; // 재사용
    private MonoBehaviour destroyed; // 사용중 파괴 가능

    public void Init(){}

    public void StartCoroutine(IEnumerator coroutine, bool isDondestroy = false)
    {
        if (isDondestroy)
        {
            if (dondestroy == null)
            {
                dondestroy = Managers.Manager;
            }
                dondestroy.StartCoroutine(coroutine);   
        }
        else
        {
            if (destroyed == null)
            {
                GameObject clone = new GameObject();
                clone.name = $"{Defines.ManagerType.CoroutineManager}";
                destroyed = clone.AddComponent<CoroutineController>();
            }
            destroyed.StartCoroutine(coroutine);
        }
    }

    public void StopCoroutine(IEnumerator coroutine, bool isDondestroy = false)
    {
        if (isDondestroy)
        {
            if (dondestroy == null)
            {
                dondestroy = Managers.Manager.gameObject.GetComponent<MonoBehaviour>();
            }
            dondestroy.StopCoroutine(coroutine);
        }
        else
        {
            if (destroyed == null)
            {
                GameObject clone = new GameObject();
                clone.name = $"{Defines.ManagerType.CoroutineManager}";
                destroyed = clone.AddComponent<CoroutineController>();
            }
            destroyed.StopCoroutine(coroutine);
        }
    }
    
     public void StopAllCoroutines(bool isDondestroy = false)
    {
        if (isDondestroy)
        {
            if (dondestroy == null)
            {
                dondestroy = Managers.Manager.gameObject.GetComponent<MonoBehaviour>();
            }
            dondestroy.StopAllCoroutines();
        }
        else
        {
            if (destroyed == null)
            {
                GameObject clone = new GameObject();
                clone.name = $"{Defines.ManagerType.CoroutineManager}";
                destroyed = clone.AddComponent<CoroutineController>();
            }
            destroyed.StopAllCoroutines();
        }
    }
    
    public WaitForSeconds GetWfs(float duration)
    {
        if (_wfs.ContainsKey(duration))
            return _wfs[duration];
        else
        {
            _wfs[duration] = new WaitForSeconds(duration);
            return _wfs[duration];
        }
    }
}