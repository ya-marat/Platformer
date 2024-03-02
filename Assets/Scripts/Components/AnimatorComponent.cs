using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorComponent : BaseCharacterComponent
{
    private readonly int AnimatorStateHash = Animator.StringToHash("State");
    private readonly int AnimatorYVelocity = Animator.StringToHash("YVelocity");
    
    private Animator _animator;
    
    public override void UpdateComponent(ICharacterEntity characterEntity)
    {
        if (_animator == null)
        {
            _animator = characterEntity.Animator;
        }

        int state = 0;

        var moveComponent = characterEntity.ComponentsHolder.GetComponent<MoveHorizontalComponent>();

        if (characterEntity.Rigidbody2D.velocity.y != 0)
        {
            state = 2;
        }
        else if(moveComponent.MoveDirection != Vector2.zero)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }

        _animator.SetInteger(AnimatorStateHash, state);
        _animator.SetFloat(AnimatorYVelocity, characterEntity.Rigidbody2D.velocity.y);
    }
}
