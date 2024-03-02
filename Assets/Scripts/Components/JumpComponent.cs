using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : BaseCharacterComponent
{
        
    // Move to config
    private bool _isJumping;
    private Vector2 _gravityVector;
    private float _jumpCounter;
    private float _jumpTime = 0.1f;
    private float _jumpPower = 2f;
    private float _fallMultiplier = .2f;
    private float _jumpMultiplier = 0.5f;

    private GroundComponent _groundComponent;
    
    public JumpComponent()
    {
        _gravityVector = new Vector2(0, -Physics2D.gravity.y);
    }

    public override void InitComponent(ICharacterEntity characterEntity)
    {
        _groundComponent = characterEntity.ComponentsHolder.GetComponent<GroundComponent>();
    }

    public override void FixedUpdateComponent(ICharacterEntity characterEntity)
    {
        if (characterEntity.Input.Jump && _groundComponent.IsGround)
        { 
            characterEntity.Rigidbody2D.velocity = new Vector2(characterEntity.Rigidbody2D.velocity.x, _jumpPower);
            _isJumping = true;
            _jumpCounter = 0;
        }

        if (characterEntity.Rigidbody2D.velocity.y > 0 && _isJumping)
        {
            _jumpCounter += Time.deltaTime;
            if (_jumpCounter > _jumpTime)
            {
                _isJumping = false;
            }

            float t = _jumpCounter / _jumpTime;
            float currentJumpMultiplier = _jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpMultiplier = _jumpMultiplier * (1 - t);
            }
            
            //characterEntity.Rigidbody2D.velocity += _gravityVector * currentJumpMultiplier * Time.deltaTime;
            characterEntity.Rigidbody2D.velocity += _gravityVector * currentJumpMultiplier;
        }


        if (characterEntity.Rigidbody2D.velocity.y < 0)
        {
            characterEntity.Rigidbody2D.velocity -= _gravityVector * (_fallMultiplier);
        }

        if (characterEntity.Input.Jump)
        {
            _isJumping = false;
            _jumpCounter = 0;

            if (characterEntity.Rigidbody2D.velocity.y > 0)
            {
                characterEntity.Rigidbody2D.velocity = new Vector2(characterEntity.Rigidbody2D.velocity.x, characterEntity.Rigidbody2D.velocity.y * 0.8f);
            }
        }
    }
}
