using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float normalizedValue;
    
    [Inject] private PlayerCamera _playerCamera;

    private SpriteRenderer _spriteRenderer;

    private float xLeftMaxEdge;
    private float xRightMaxEdge;
    private float distance;
    private float mapDistance;
    private float _spriteWidth;

    private Vector2 _mapEndPoint = Vector2.right * 80;
    private Vector2 _starPoint = Vector2.right * -70;

    public void Init()
    {
        
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteWidth = _spriteRenderer.sprite.bounds.size.x;
        CalculateCameraEdgesPosition();
        distance = Mathf.Abs(xRightMaxEdge - xLeftMaxEdge);
        mapDistance = (_mapEndPoint - _starPoint).sqrMagnitude;
    }

    private void LateUpdate()
    {
        UpdateBGPosition();
    }

    private void UpdateBGPosition()
    {
        CalculateCameraEdgesPosition();
        CalculateNormalizeBetweenCharacterAndEndPoint();
        var cameraPosition = _playerCamera.transform.position;
        cameraPosition.z = 0;
        cameraPosition.x = xLeftMaxEdge - distance * normalizedValue;
        transform.position = cameraPosition;
    }

    private void CalculateCameraEdgesPosition()
    {
        xRightMaxEdge = ((float)Screen.width / Screen.height * _playerCamera.GameCamera.orthographicSize - (_spriteWidth / 2 * _spriteRenderer.transform.localScale.x));
        xRightMaxEdge += _playerCamera.GameCamera.transform.position.x;
        xLeftMaxEdge = -((float)Screen.width / Screen.height * _playerCamera.GameCamera.orthographicSize - (_spriteWidth / 2 * _spriteRenderer.transform.localScale.x));
        xLeftMaxEdge += _playerCamera.GameCamera.transform.position.x;
    }

    private void CalculateNormalizeBetweenCharacterAndEndPoint()
    {
        var endPointCharacterDistance = (_mapEndPoint - (Vector2)_playerCamera.GameCamera.transform.position).sqrMagnitude;
        normalizedValue = (mapDistance - endPointCharacterDistance) / mapDistance;
    }
}
