namespace ITPrime;

public interface ICommandService<TCommand>
{
    void Execute(TCommand command);
}
