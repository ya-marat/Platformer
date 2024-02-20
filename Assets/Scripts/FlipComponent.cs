using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipComponent : BaseCharacterComponent
{
    private float _flipValue;
    private GameObject _entity;
    
    public FlipComponent(GameObject entity)
    {
        _entity = entity;
    }
    
    public void Flip(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }
        
        _flipValue = direction.x > 0 ? 1 : -1;
        var scale = _entity.transform.localScale;
        scale.x = _flipValue;
        _entity.transform.localScale = scale;
    }
    
    public override void UpdateComponent(float deltaTime)
    {
        
    }
}
