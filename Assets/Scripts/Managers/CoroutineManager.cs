using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineManager
{
    private Dictionary<float, WaitForSeconds> _wfs = new();
    private MonoBehaviour _manager;
    private MonoBehaviour _scene;

    public void Init()
    {
        _manager = Managers.Manager;
    }

    public void SetSceneCorouine(Transform sceneController)
    {
        _scene = sceneController.GetComponent<Scene_Base_Controller>();
    }

    public void StartCoroutine(IEnumerator coroutine, bool immotal = false)
    {
        if (immotal)    _manager.StartCoroutine(coroutine);   
      
        else    _scene.StartCoroutine(coroutine);
    }

    public void StopCoroutine(IEnumerator coroutine, bool immotal = false)
    {
        if (immotal)     _manager.StopCoroutine(coroutine);

        else    _scene.StopCoroutine(coroutine);
    }
    
     public void StopAllCoroutines(bool immotal = false)
    {
        if (immotal)    _manager.StopAllCoroutines();
      
        else     _scene.StopAllCoroutines();
    }
    
    public WaitForSeconds GetWfs(float duration)
    {
        if (_wfs.ContainsKey(duration))
            return _wfs[duration];
        
        _wfs[duration] = new WaitForSeconds(duration);
        return _wfs[duration];
    }
}