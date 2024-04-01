using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class MapController : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    
    private float leftMapPosition;
    private float rightMapPosition;
    private Vector2 _mapSize;
    private float downBorderMapYValue;
    private float upBorderMapYValue;
    
    public float LeftBorderMapPosition => leftMapPosition;
    public float RightBorderMapPosition => rightMapPosition;
    public float DownBorderMapYValue => downBorderMapYValue;
    public float UpBorderMapYValue => upBorderMapYValue;
    public Vector2 MapSize => _mapSize;

    public void Init()
    {
        _tilemap.CompressBounds();
        var cellBounds = _tilemap.cellBounds;
        var leftBorderMap = cellBounds.xMin;
        var rightBorderMap = cellBounds.xMax;
        var downBorderMap = cellBounds.yMin;
        var upBorderMap = cellBounds.yMax;
        _mapSize = _tilemap.CellToWorld(_tilemap.size);
        leftMapPosition = _tilemap.CellToWorld(Vector3Int.right * leftBorderMap).x;
        rightMapPosition = _tilemap.CellToWorld(Vector3Int.right * rightBorderMap).x;
        downBorderMapYValue =  _tilemap.CellToWorld(Vector3Int.up * downBorderMap).y;
        upBorderMapYValue =  _tilemap.CellToWorld(Vector3Int.up * upBorderMap).y;
        
        Debug.Log($"Map {downBorderMapYValue} {upBorderMapYValue}");
    }
}