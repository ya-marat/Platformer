using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    IReadOnlyReactiveProperty<Vector2> InputValue { get; }
}
