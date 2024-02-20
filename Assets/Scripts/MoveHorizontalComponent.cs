using System;
using UniRx;
using UnityEngine;

public class MoveHorizontalComponent : BaseCharacterComponent
{
    private Rigidbody2D _rigidbody;
    private Vector2 _currentMoveDirection;
    private float _deltaTime;

    public float MoveSpeed { get; set; }
    public Vector2 MoveDirection => _currentMoveDirection;
    
    public MoveHorizontalComponent(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void Move(Vector2 direction)
    {
        _currentMoveDirection = direction;
        float xMove = _currentMoveDirection.x * MoveSpeed * 60 * _deltaTime;
        _rigidbody.velocity = new Vector2(xMove, _rigidbody.velocity.y);
    }

    public override void UpdateComponent(float deltaTime)
    {
        _deltaTime = deltaTime;
    }
}
