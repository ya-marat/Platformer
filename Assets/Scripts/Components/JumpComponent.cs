using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : BaseCharacterComponent
{
    private const float MaxHeight = 2f;
    
    private bool _isJumping;
    private bool _isJumpingPressed;
    private Vector2 _gravityVector;
    private float _jumpCounter;
    private float _jumpTime;
    private float _jumpPower;
    private float _fallMultiplier;
    private float _jumpMultiplier;

    private GroundComponent _groundComponent;
    
    public JumpComponent(float jumpTime, float jumpPower, float fallMultiplier, float jumpMultiplier)
    {
        _jumpTime = jumpTime;
        _jumpPower = jumpPower;
        _fallMultiplier = fallMultiplier;
        _jumpMultiplier = jumpMultiplier;
        _gravityVector = new Vector2(0, -Physics2D.gravity.y);
    }

    public override void InitComponent(ICharacterEntity characterEntity)
    {
        _groundComponent = characterEntity.ComponentsHolder.GetComponent<GroundComponent>();
    }

    public override void FixedUpdateComponent(ICharacterEntity characterEntity)
    {
        if (characterEntity.Input.Jump && _groundComponent.IsGround && !_isJumpingPressed)
        { 
            characterEntity.Rigidbody2D.velocity = new Vector2(characterEntity.Rigidbody2D.velocity.x, _jumpPower);
            _isJumping = true;
            _isJumpingPressed = true;
            _jumpCounter = 0;

            //_currentYPosition = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * _jumpPower);
            //characterEntity.Rigidbody2D.velocity = new Vector2(characterEntity.Rigidbody2D.velocity.x, yvel);
            
            
        }

        if (_isJumping)
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
            
            characterEntity.Rigidbody2D.velocity += _gravityVector * currentJumpMultiplier;
        }
        else
        {
            characterEntity.Rigidbody2D.velocity -= _gravityVector * (_fallMultiplier);
        }

        if (!characterEntity.Input.Jump && _isJumpingPressed)
        {
            _isJumping = false;
            _isJumpingPressed = false;
            _jumpCounter = 0;

            if (characterEntity.Rigidbody2D.velocity.y > 0)
            {
                characterEntity.Rigidbody2D.velocity = new Vector2(characterEntity.Rigidbody2D.velocity.x, characterEntity.Rigidbody2D.velocity.y * 0.5f);
            }
        }
    }

    [Obsolete("This method will be deleted, when set a right balance of the jumo")]
    public void Set(float jumpTime, float jumpPower, float fallMultiplier, float jumpMultiplier)
    {
        _jumpTime = jumpTime;
        _jumpPower = jumpPower;
        _fallMultiplier = fallMultiplier;
        _jumpMultiplier = jumpMultiplier;
    }
}
