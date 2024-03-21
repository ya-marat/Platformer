using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerPlayerInput : MonoBehaviour, ICommandHolderGetter
{
    private Vector2 _input;
    private bool _fire;
    private bool _jump;
    private Command<Vector2> _moveCommand = new Command<Vector2>(Vector2.zero);
    private Command<bool> _jumpCommand = new Command<bool>(false);
    private CommandsHolder _commandsHolder = new CommandsHolder();

    public ICommandsHolder CommandsHolder => _commandsHolder;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _commandsHolder.RegisterCommand(CommandType.Move, _moveCommand);
        _commandsHolder.RegisterCommand(CommandType.Jump, _jumpCommand);
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Character.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Character.Disable();
    }

    private void Update()
    {
        var xInput = _playerInput.Character.Move.ReadValue<Vector2>();
        _jump = _playerInput.Character.Jump.IsPressed();
        _input = new Vector2(xInput.x, 0);
        
        _moveCommand.ExecuteCommand(_input);
        _jumpCommand.ExecuteCommand(_jump);
    }
}