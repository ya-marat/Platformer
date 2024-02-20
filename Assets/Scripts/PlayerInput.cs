using UniRx;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private ReactiveProperty<Vector2> _input = new();

    public IReadOnlyReactiveProperty<Vector2> InputValue => _input;

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        _input.Value = new Vector2(xInput, 0);
    }
}
