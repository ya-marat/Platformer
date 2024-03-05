using System;
using System.Collections.Generic;
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

    private Dictionary<string, object> _inputs = new Dictionary<string, object>();

    public void SetIn<T>(string inputName, T value)
    {
        if (_inputs.ContainsKey(inputName))
        {
            _inputs[inputName] = value;
        }
        else
        {
            _inputs.Add(inputName, value);
        }
        
       
    }

    public T GetIn<T>(string inputName)
    {
        return _inputs[inputName] is T ? (T) _inputs[inputName] : default;
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        
        _jump = Input.GetKey(KeyCode.Space);
        _input = new Vector2(xInput, 0);
        
        SetIn("Move" ,xInput);
        SetIn("Jump", _jump);
    }
}
