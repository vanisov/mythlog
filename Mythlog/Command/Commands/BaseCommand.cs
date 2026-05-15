namespace Mythlog.Command.Commands;

public abstract class BaseCommand : ICommand
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract string Usage { get; }

    public virtual string[] Aliases => [];
    public virtual CommandArg[] Args => [];

    public abstract Task<CommandResult> Execute(
        CommandContext ctx,
        ICommandRuntimeContext runtime
    );
}