public interface ICommand{}
public interface ICommandStatus<out T> : ICommand
{
    public bool WasExecute { get;}
    public bool WasReleased { get;}
    public bool IsExecuting { get;}
    public T Value { get; }
}
