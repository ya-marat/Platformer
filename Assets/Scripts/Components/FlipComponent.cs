using UnityEngine;

public class FlipComponent : BaseCharacterComponent
{
    private float _flipValue;
    private MoveHorizontalComponent _moveHorizontalComponent;
    
    
    public override void UpdateComponent(ICharacterEntity characterEntity)
    {
    }

    public override void FixedUpdateComponent(ICharacterEntity characterEntity)
    {
        if (_moveHorizontalComponent == null)
        {
            _moveHorizontalComponent = characterEntity.ComponentsHolder.GetComponent<MoveHorizontalComponent>();
        }

        var direction = _moveHorizontalComponent.MoveDirection;
        
        if (direction == Vector2.zero)
        {
            return;
        }
        
        _flipValue = direction.x > 0 ? 1 : -1;
        var scale = characterEntity.EntityTransform.localScale;
        scale.x = _flipValue;
        characterEntity.EntityTransform.localScale = scale;
    }
}
