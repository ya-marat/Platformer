using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform playerView;
    
    private List<BaseCharacterComponent> _components = new();
    private MoveHorizontalComponent _moveHorizontalComponent;
    private FlipComponent _flipComponent;

    private void InitComponents()
    {
        _moveHorizontalComponent = new MoveHorizontalComponent(_rigidbody2D);
        _moveHorizontalComponent.MoveSpeed = 10;

        _flipComponent = new FlipComponent(gameObject);

        _components.Add(_moveHorizontalComponent);
    }
    
    private void Awake()
    {
        InitComponents();
    }

    private void Update()
    {
        foreach (var component in _components)
        {
            component.UpdateComponent(Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        _moveHorizontalComponent.Move(playerInput.InputValue.Value);
        _flipComponent.Flip(_moveHorizontalComponent.MoveDirection);
    }
}