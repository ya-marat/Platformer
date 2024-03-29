using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10f);

    [Inject] private MapController _mapController;

    private Transform _cameraTarget;
    private Vector3 velocity;
    private Camera _camera;
    private float halfWidth;
    private float leftEdgeCameraPosition;
    private float availableCameraXPosRange;

    private float _xRighMaxCameraPosition;
    private float _xLeftMaxCameraPosition;
    private float yUpEdge = 20f;
    private float yDownEdge = 0f;
    
    public float LeftEdgeCameraPosition => -halfWidth + transform.position.x;
    public float RightEdgeCameraPosition => halfWidth + transform.position.x;
    public float XLeftMaxCameraPosition => _xLeftMaxCameraPosition;
    public float XRightMaxCameraPosition => _xRighMaxCameraPosition;
    public float AvailableCameraXPosRange => availableCameraXPosRange;
    public Camera GameCamera => _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        halfWidth = _camera.aspect * _camera.orthographicSize;
    }

    public void Init(Transform target)
    {
        _cameraTarget = target;
        _xLeftMaxCameraPosition = _mapController.LeftBorderMapPosition.x + halfWidth;
        _xRighMaxCameraPosition = _mapController.RightBorderMapPosition.x - halfWidth;
        availableCameraXPosRange = _mapController.MapHorizontalSize.x - halfWidth * 2;
    }

    private void LateUpdate()
    {
        if (_cameraTarget == null) return;

        var target = _cameraTarget.position + _offset;
        target = new Vector3(Mathf.Clamp(target.x, _xLeftMaxCameraPosition, _xRighMaxCameraPosition), 
            Mathf.Clamp(target.y, yDownEdge, yUpEdge), target.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, _smoothTime);
    }

}
