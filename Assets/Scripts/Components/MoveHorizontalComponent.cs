using System;
using UniRx;
using UnityEngine;

public class MoveHorizontalComponent : BaseCharacterComponent, IMoveDirection
{
    private Vector2 _currentMoveDirection;
    private ICommandStatus<Vector2> _moveCommandStatus;
    private float _flipValue;
    private float _acceleration;

    public float MoveSpeed { get; }
    public Vector2 MoveDirection => _currentMoveDirection;

    public MoveHorizontalComponent(float moveSpeed, float acceleration)
    {
        MoveSpeed = moveSpeed;
        _acceleration = acceleration;
    }

    public override void InitComponent(ICharacterEntity characterEntity)
    {
        _moveCommandStatus = characterEntity.CommandsHolder.GetCommandStatus<Vector2>(CommandType.Move);
    }

    public override void UpdateComponent(ICharacterEntity characterEntity)
    {
        var direction = MoveDirection;
        
        if (direction == Vector2.zero)
        {
            return;
        }
        
        _flipValue = direction.x > 0 ? 1 : -1;
        var scale = characterEntity.EntityTransform.localScale;
        scale.x = _flipValue;
        characterEntity.EntityTransform.localScale = scale;
    }

    public override void FixedUpdateComponent(ICharacterEntity characterEntity)
    {
        var direction = _moveCommandStatus.Value.normalized;
        _currentMoveDirection = direction;
        float xMove = _currentMoveDirection.x * MoveSpeed;
        characterEntity.Rigidbody2D.velocity = new Vector2(xMove, characterEntity.Rigidbody2D.velocity.y);
        Debug.Log($"Velocity {characterEntity.Rigidbody2D.velocity.x}");
    }
}

