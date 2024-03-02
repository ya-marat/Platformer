using UniRx;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private Vector2 _input;
    private bool _fire;
    private bool _jump;
    
    public Vector2 MoveDirection => _input;
    public bool Jump => _jump;
    public bool Fire => _fire;

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        _jump = Input.GetKeyDown(KeyCode.Space);
        _input = new Vector2(xInput, 0);
    }
}
