using System.Collections.Generic;
using UnityEngine;

public enum CommandType
{
    Move,
    Jump,
}

public interface ICommandHolderGetter
{
    ICommandsHolder CommandsHolder { get; }
}

public interface ICommandsHolder
{
    public ICommandStatus<T> GetCommandStatus<T>(CommandType type);
}

public class CommandsHolder : ICommandsHolder
{
    private Dictionary<CommandType, ICommand> _commandStatus = new();
    
    public void RegisterCommand<T>(CommandType type, ICommandStatus<T> newCommand)
    {
        _commandStatus.Add(type, newCommand);
    }

    public ICommandStatus<T> GetCommandStatus<T>(CommandType type)
    {
        return _commandStatus[type] as ICommandStatus<T>;
    }
}
