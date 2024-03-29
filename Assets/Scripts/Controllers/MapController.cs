using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class MapController : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    
    private Vector2 leftMapPosition;
    private Vector2 rightMapPosition;
    private Vector2 mapHorizontalSize;
    
    public Vector2 LeftBorderMapPosition => leftMapPosition;
    public Vector2 RightBorderMapPosition => rightMapPosition;
    public Vector2 MapHorizontalSize => mapHorizontalSize;

    public void Init()
    {
        _tilemap.CompressBounds();
        var cellBounds = _tilemap.cellBounds;
        var leftBorderCell = cellBounds.xMin;
        var rightBorderCell = cellBounds.xMax;
        mapHorizontalSize = _tilemap.CellToWorld(_tilemap.size);
        leftMapPosition = _tilemap.CellToWorld(Vector3Int.right * leftBorderCell);
        rightMapPosition = _tilemap.CellToWorld(Vector3Int.right * rightBorderCell);
    }
}