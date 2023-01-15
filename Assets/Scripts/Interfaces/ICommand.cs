using Cysharp.Threading.Tasks;

public interface ICommand
{
    public void Execute();
}
public interface ICommand<TContext>
{
    public void Execute(ref TContext context);
}

public interface IAsyncCommand
{
    public UniTask ExecuteAsync();
}
public interface IAsyncCommand<TContext>
{
    public UniTask ExecuteAsync(ref TContext context);
}

public interface IAsyncCommand<TContext, TReturn>
{
    public UniTask<TReturn> ExecuteAsync(ref TContext context);
}