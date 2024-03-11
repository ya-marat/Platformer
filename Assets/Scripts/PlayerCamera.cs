using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10f);
    
    private Transform _cameraTarget;
    private Vector3 velocity;

    private float xRighEdge = 50f;
    private float xLeftEdge = -50f;
    private float yUpEdge = 20f;
    private float yDownEdge = -20f;

    public void Init(Transform target)
    {
        _cameraTarget = target;
    }
    
    private void LateUpdate()
    {
        if (_cameraTarget == null) return;
        
        var target = _cameraTarget.position + _offset;
        target = new Vector3(Mathf.Clamp(target.x, xLeftEdge, xRighEdge), Mathf.Clamp(target.y, yDownEdge, yUpEdge),
            target.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, _smoothTime);
    }
}
