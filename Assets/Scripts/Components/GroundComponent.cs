using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GroundComponent : BaseCharacterComponent
{
    private bool _isGround = true;
    private RaycastHit2D[] _hits2D;
    private int _layerMask;
    private float _distance;
    private int _castsCount;
    private Vector2 _boxCollideSize;
    
    public bool IsGround => _isGround;

    public GroundComponent(int layerMask)
    {
        _layerMask = layerMask;
        _hits2D = new RaycastHit2D [2];
        _boxCollideSize = new Vector2(2, 1);
        _distance = 0.1f;
    }

    public override void UpdateComponent(ICharacterEntity characterEntity)
    {
        _castsCount = Physics2D.BoxCastNonAlloc((Vector2)characterEntity.GroundCheckerTransform.transform.position + Vector2.up * 0.5f , 
            _boxCollideSize , .1f, Vector2.down, _hits2D, _distance, _layerMask);

        _isGround = _castsCount != 0;
    }
}
