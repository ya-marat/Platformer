using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterEntity
{
    public ICommandsHolder CommandsHolder { get; }
    public Rigidbody2D Rigidbody2D { get; }
    public Animator Animator { get; }
    public Transform EntityTransform { get; }
    public Transform GroundCheckerTransform { get; }
    public ComponentsHolder ComponentsHolder { get; }
}
