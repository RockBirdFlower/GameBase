using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager
{
    private Dictionary<float, WaitForSeconds> _wfs = new();
    private MonoBehaviour dondestroy; // 재사용
    private MonoBehaviour destroyed; // 사용중 파괴 가능

    public void StartCoroutine(IEnumerator coroutine, bool isDondestroy=false)
    {
        if (isDondestroy)
        {
            if (dondestroy == null)
            {
                dondestroy = GameManager.Game.gameObject.GetComponent<MonoBehaviour>();
            }
            dondestroy.StartCoroutine(coroutine);
        }
        else
        {
            if (destroyed == null)
            {
                GameObject clone = new GameObject();
                clone.name = "CroutineManager";
                destroyed = clone.AddComponent<CoroutineController>();
            }
            destroyed.StartCoroutine(coroutine);
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