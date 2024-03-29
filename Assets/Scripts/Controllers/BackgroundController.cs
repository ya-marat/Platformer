using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float normalizedValue;
    
    [Inject] private PlayerCamera _playerCamera;
    [Inject] private MapController _mapController;

    private SpriteRenderer _spriteRenderer;

    private float xLeftMaxEdge;
    private float mapDistance;
    private float spriteBgWidth;
    private float bgSpriteMoveAvailableDistance;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spriteBgWidth = _spriteRenderer.sprite.bounds.size.x;
        Debug.Log($"Map distance {mapDistance}");
    }

    public void Init()
    {
        CalculateBgPosition();
        Vector2 cameraPos = _playerCamera.GameCamera.transform.position;
        bgSpriteMoveAvailableDistance = (cameraPos - new Vector2(xLeftMaxEdge, 0)).magnitude * 2;
    }

    private void LateUpdate()
    {
        UpdateBGPosition();
    }

    private void UpdateBGPosition()
    {
        CalculateBgPosition();
        var cameraPosition = _playerCamera.transform.position;
        cameraPosition.z = 0;
        cameraPosition.x = xLeftMaxEdge - bgSpriteMoveAvailableDistance * normalizedValue;
        transform.position = cameraPosition;
    }

    private void CalculateBgPosition()
    {
        xLeftMaxEdge = _playerCamera.LeftEdgeCameraPosition + spriteBgWidth / 2 * _spriteRenderer.transform.localScale.x;
        var endPointCharacterDistance = Mathf.Abs(_playerCamera.XLeftEdge -_playerCamera.transform.position.x);
        normalizedValue = endPointCharacterDistance / _playerCamera.AvailableCameraXPosRange;
    }

    private void OnDrawGizmos()
    {
        if (_playerCamera == null) return;
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(new Vector3(_playerCamera.transform.position.x, 0, 0), 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(xLeftMaxEdge, 0 , 0), 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(xLeftMaxEdge - bgSpriteMoveAvailableDistance, 0 , 0), 0.5f);
    }
}
