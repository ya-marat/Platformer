using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, ICharacterEntity
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _groundCheckerTransform;
    
    [Inject] private ICommandHolderGetter _commandHolderGetter;
    [Inject] private GameConfig _gameConfig;
    
    private ComponentsHolder _componentsHolder = new();

    public ICommandsHolder CommandsHolder => _commandHolderGetter.CommandsHolder;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => _animator;
    public Transform EntityTransform => transform;
    public Transform GroundCheckerTransform => _groundCheckerTransform;
    public ComponentsHolder ComponentsHolder => _componentsHolder;

    public void Init()
    {
        foreach (var component in _componentsHolder.Components)
        {
            component.InitComponent(this);
        }
    }

    private void Update()
    {
        foreach (var component in _componentsHolder.Components)
        {
            component.UpdateComponent(this);
        }
    }

    private void FixedUpdate()
    {
        foreach (var component in _componentsHolder.Components)
        {
            component.FixedUpdateComponent(this);
        }
    }

    private void OnDrawGizmos()
    {
        if (_componentsHolder != null)
        {
            var groundComponent = _componentsHolder.GetComponent<GroundComponent>();
            if (groundComponent != null)
            {
                Gizmos.color = groundComponent.IsGround ? Color.red : Color.cyan;
                Gizmos.DrawWireCube((Vector2)GroundCheckerTransform.position + Vector2.up * 0.5f, new Vector2(2, 1));
            }
        }
    }
}