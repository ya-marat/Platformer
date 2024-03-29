using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float normalizedValue;
    
    [Inject] private PlayerCamera _playerCamera;

    private SpriteRenderer _spriteRenderer;

    private float xLeftMaxEdge;
    private float mapDistance;
    private float spriteBgWidth;
    private float bgSpriteMoveAvailableDistance;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spriteBgWidth = _spriteRenderer.sprite.bounds.size.x;
    }

    public void Init()
    {
        CalculateBgPosition();
        Vector2 cameraPos = _playerCamera.GameCamera.transform.position;
        bgSpriteMoveAvailableDistance = (xLeftMaxEdge - cameraPos.x) * 2;
    }

    private void LateUpdate()
    {
        UpdateBGPosition();
    }

    private void UpdateBGPosition()
    {
        CalculateBgPosition();
        transform.position = new Vector3(xLeftMaxEdge - bgSpriteMoveAvailableDistance * normalizedValue, 0, 0);;
    }

    private void CalculateBgPosition()
    {
        xLeftMaxEdge = _playerCamera.LeftEdgeCameraPosition + spriteBgWidth / 2 * _spriteRenderer.transform.localScale.x;
        var endPointCharacterDistance = Mathf.Abs(_playerCamera.XLeftMaxCameraPosition -_playerCamera.transform.position.x);
        normalizedValue = endPointCharacterDistance / _playerCamera.AvailableCameraXPosRange;
    }
}
