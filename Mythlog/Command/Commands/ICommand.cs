namespace Mythlog.Command.Commands;

public interface ICommand
{
    string Name { get; }
    string Description { get; }
    string Usage { get; }

    string[] Aliases { get; }
    CommandArg[] Args { get; }

    Task<CommandResult> Execute(
        CommandContext ctx,
        ICommandRuntimeContext runtime
    );
}