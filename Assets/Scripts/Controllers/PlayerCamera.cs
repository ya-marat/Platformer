using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10f);

    [Inject] private MapController _mapController;
    [Inject] private GameConfig _gameConfig;

    private Transform _cameraTarget;
    private float _smoothTime;
    private Vector3 _velocity = Vector3.one * 2;
    private Camera _camera;
    private float _halfWidth;
    private float _leftEdgeCameraPosition;
    private float _rightMaxCameraPosition;
    private float _leftMaxCameraPosition;
    private float _upMaxCameraPosition;
    private float _downMaxCameraPosition;
    
    public float LeftEdgeCameraPosition => -_halfWidth + transform.position.x;
    public float DownEdgeCameraPosition => -_camera.orthographicSize + transform.position.y;
    public float LeftMaxCameraPosition => _leftMaxCameraPosition;
    public float DownMaxCameraPosition => _downMaxCameraPosition;
    public float XAvailableCameraPosRange => Mathf.Abs(_rightMaxCameraPosition - _leftMaxCameraPosition);
    public float YAvailableCameraPosRange => Mathf.Abs(_upMaxCameraPosition - _downMaxCameraPosition);
    public Camera GameCamera => _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _halfWidth = _camera.aspect * _camera.orthographicSize;
    }

    public void Init(Transform target)
    {
        _cameraTarget = target;
        _smoothTime = _gameConfig.PlayerConfig.CameraSmoothTime;
        _leftMaxCameraPosition = _mapController.LeftBorderMapPosition + _halfWidth;
        _rightMaxCameraPosition = _mapController.RightBorderMapPosition - _halfWidth;
        _downMaxCameraPosition = _mapController.DownBorderMapYValue + _camera.orthographicSize;
        _upMaxCameraPosition = _mapController.UpBorderMapYValue;
    }
    private void LateUpdate()
    {
        if (_cameraTarget == null) return;

        var target = _cameraTarget.position + _offset;
        target = new Vector3(Mathf.Clamp(target.x, _leftMaxCameraPosition, _rightMaxCameraPosition), 
            Mathf.Clamp(target.y, _downMaxCameraPosition, _upMaxCameraPosition), target.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, _smoothTime * Time.deltaTime);
    }
}
