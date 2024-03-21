
using UnityEngine;

public class Command<T> : ICommandStatus<T>
{
    private CommandState _currentCommandState = CommandState.None;
    private T _defaultValue;
    private T _currentValue;
    
    public virtual bool WasExecute => _currentCommandState == CommandState.StartExecute;
    public virtual bool WasReleased => _currentCommandState == CommandState.Release;
    public bool IsExecuting => _currentCommandState == CommandState.Executing;
    public T Value => _currentValue;

    private CommandState State => _currentCommandState;

    public Command(T defaultDefaultValue)
    {
        _defaultValue = defaultDefaultValue;
    }

    public void ExecuteCommand(T value = default)
    {
        if (!value.Equals(_defaultValue))
        {
            CommandState newState = State switch
            {
                CommandState.None => CommandState.StartExecute,
                CommandState.StartExecute => CommandState.Executing,
                _ => State
            };

            _currentCommandState = newState;
        }
        else
        {
            CommandState newState = State switch
            {
                CommandState.Executing => CommandState.Release,
                CommandState.Release => CommandState.None,
                _ => State
            };

            _currentCommandState = newState;
        }
        
        _currentValue = value;
    }
}