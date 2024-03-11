using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Object = System.Object;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private Vector2 _input;
    private bool _fire;
    private bool _jump;
    
    public Vector2 MoveDirection => _input;
    public bool Jump => _jump;
    public bool Fire => _fire;

    private Dictionary<string, object> _inputs = new Dictionary<string, object>();

    private ICommandsHolder _commandsHolder = new CommandsHandler();
    private Command<bool> _jumpCommand = new();
    

    private async UniTask Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        

        _jumpCommand.ExecuteCommand();

        string log = "";
        
        if (_jumpCommand.WasExecute)
        {
            log += "Execute ";
        }

        if (_jumpCommand.WasReleased)
        {
            log += "Released";
        }
        
        
        Debug.Log($"{log}");
        
        _jump = Input.GetKey(KeyCode.Space);
        _input = new Vector2(xInput, 0);
    }
}

public interface ICommandStatus
{
    public bool WasExecute { get;}
}

public class Command<T>  : ICommandStatus
{
    private bool _isCommandExecuting = false;
    private T _value;

    private bool _called = false;
    private bool _released = false;
    
    public bool WasExecute { get; private set; }
    public bool WasReleased { get; private set; }
    public bool IsExecuting => _isCommandExecuting;
    
    
    public T CommandValue => _value;
    
    public virtual void ExecuteCommand(T value = default)
    {
        if (_called)
        {
            WasExecute = false;
            return;
        }
        
        _value = value;
        WasExecute = true;
        _called = true;
        _released = false;
        _isCommandExecuting = true;
        
    }

    public virtual void ReleaseCommand()
    {
        if (_released)
        {
            WasReleased = false;
            return;
        }
        
        WasReleased = !_released;
        _released = true;
        _called = false;
        _isCommandExecuting = false;
        _value = default;
    }
}

public class JumpCommand : Command<bool>
{
    public override void ExecuteCommand(bool value = default)
    {
        base.ExecuteCommand(value);
        if (!value)
        {
            ReleaseCommand();
        }
    }
}

public interface ICommandsHolder
{
    public ICommandStatus GetCommandStatus<T>();
}

public class CommandsHandler : ICommandsHolder
{
    private List<ICommandStatus> _commands = new();

    public CommandsHandler()
    {
        Init();
    }
    
    public void Init()
    {

    }

    public ICommandStatus GetCommandStatus<T>()
    {
        var c = _commands.FirstOrDefault(e => e.GetType() == typeof(T));
        return c;
    }
}
