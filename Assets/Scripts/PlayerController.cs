using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacterEntity
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _groundCheckerTransform;
    [SerializeField] private LayerMask _layerMask;
    
    private ComponentsHolder _componentsHolder = new();
    private IPlayerInput _input;
    
    public IPlayerInput Input => playerInput;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => _animator;
    public Transform EntityTransform => transform;
    public Transform GroundCheckerTransform => _groundCheckerTransform;
    public ComponentsHolder ComponentsHolder => _componentsHolder;
    
    public void Init(IPlayerInput input)
    {
        _input = input;
    }
    
    private void Awake()
    {
        _componentsHolder.AddComponent(new MoveHorizontalComponent(10));
        _componentsHolder.AddComponent(new FlipComponent());
        _componentsHolder.AddComponent(new AnimatorComponent());
        _componentsHolder.AddComponent(new JumpComponent());
        _componentsHolder.AddComponent(new GroundComponent(_layerMask));
        
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