using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 MoveDirection { get; }
    bool Jump { get; }
    bool Fire { get; }
}
