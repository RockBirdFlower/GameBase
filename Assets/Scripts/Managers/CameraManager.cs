using UnityEngine;

public class CameraManager
{
    private Camera _cam;
    private Transform _target;
    private bool _isBoundsBox;
    private Vector2 _min;
    private Vector2 _max;

    public Camera MainCamera
    {
        get
        {
            if (_cam == null)
            {
                _cam = Camera.main;

                if (_cam == null)
                {
                    GameObject clone = new GameObject();
                    clone.name = $"{Defines.ManagerType.CameraManager}";
                    _cam = clone.AddComponent<Camera>();
                }
            }
            return _cam;
        }
    }


    public void SetFollowTarget(Transform target)
    {
        _target = target;
    }

    public void SetBoundsBox(Vector2 min, Vector2 max)
    {
        _isBoundsBox = true;
        _min = min;
        _max = max;
    }


    public void LateUpdateCamera()
    {
        if (_target == null) return;

        if (_isBoundsBox)
        {
            GetBoundsPosition();
        }
        else
        {
            GetDefaultPosition();
        }
        
    }

    private void GetDefaultPosition()
    {
        Vector3 position = _target.position;
        Vector3 camPosition = _cam.transform.position;
        position.z = camPosition.z;

        _cam.transform.position = position;
    }

    private void GetBoundsPosition()
    {
        Vector3 position = _target.position;
        Vector3 camPosition = _cam.transform.position;
        position.z = camPosition.z;

        position.x = Mathf.Clamp(position.x, _min.x, _max.x);
        position.y = Mathf.Clamp(position.y, _min.y, _max.y);

        _cam.transform.position = position;
    }
}