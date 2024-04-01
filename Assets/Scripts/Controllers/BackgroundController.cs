using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundController : MonoBehaviour
{
    [Inject] private PlayerCamera _playerCamera;

    private SpriteRenderer _spriteRenderer;
    private float normalizedValueX;
    private float normalizedValueY;
    private float xLeftMaxEdge;
    private float yDownMaxEdge;
    private float mapDistance;
    private Vector3 spriteBgSize;
    private float bgSpriteMoveAvailableDistanceX;
    private float bgSpriteMoveAvailableDistanceY;

    private Vector3 SpriteScale => _spriteRenderer.transform.localScale;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spriteBgSize = _spriteRenderer.sprite.bounds.size;
    }

    public void Init()
    {
        CalculateBgPosition();
        Vector2 cameraPos = _playerCamera.GameCamera.transform.position;
        bgSpriteMoveAvailableDistanceX = (xLeftMaxEdge - cameraPos.x) * 2;
        bgSpriteMoveAvailableDistanceY = (yDownMaxEdge - cameraPos.y) * 2;
    }

    private void LateUpdate()
    {
        UpdateBGPosition();
    }

    private void UpdateBGPosition()
    {
        CalculateBgPosition();
        transform.position = new Vector3(xLeftMaxEdge - bgSpriteMoveAvailableDistanceX * normalizedValueX, 
            yDownMaxEdge - bgSpriteMoveAvailableDistanceY * normalizedValueY);;
    }

    private void CalculateBgPosition()
    {
        Vector3 transformPosition = _playerCamera.transform.position;
        xLeftMaxEdge = _playerCamera.LeftEdgeCameraPosition + spriteBgSize.x / 2 * SpriteScale.x;
        yDownMaxEdge = _playerCamera.DownEdgeCameraPosition + spriteBgSize.y / 2 * SpriteScale.y;
        var xDistance = Mathf.Abs(_playerCamera.LeftMaxCameraPosition - transformPosition.x);
        var yDistance = Mathf.Abs(_playerCamera.DownMaxCameraPosition - transformPosition.y);
        normalizedValueX = Mathf.Clamp01(xDistance / _playerCamera.XAvailableCameraPosRange);
        normalizedValueY =  Mathf.Clamp01(yDistance / _playerCamera.YAvailableCameraPosRange);
        
        Debug.Log($"normal {normalizedValueX} {normalizedValueY}");
    }
}
