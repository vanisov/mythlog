using System.Text;

namespace Mythlog.Command.Commands;

public class HelpCommand(CommandRegistry registry) : BaseCommand
{
    public override string Name => "help";
    public override string Description => "Display all available commands and how to use them.";
    public override string Usage => "help <command>";

    public override CommandArg[] Args =>
    [
        new CommandArg(Name: "command", Required: false, Description: "Command to view detailed help for")
    ];

    public override Task<CommandResult> Execute(CommandContext ctx, ICommandRuntimeContext runtime)
    {
        var selectedCommand = ctx.Args.Length > 0 ? ctx.Args[0] : null;
        if (string.IsNullOrWhiteSpace(selectedCommand))
        {
            return Task.FromResult(new CommandResult(Success: true, Output: ShowAllCommands()));
        }

        var command = registry.Get(selectedCommand);
        return Task.FromResult(command == null
            ? new CommandResult(Success: false, Output: $"Unknown command: {selectedCommand}")
            : new CommandResult(Success: true, Output: ShowCommandDetails(command)));
    }

    private string ShowAllCommands()
    {
        var commands = registry.GetAll();
        var lines = new List<string> { "Available Commands:", "" };
        lines.AddRange(commands.Select(c => $"{c.Name,-14} {c.Description}"));
        lines.Add("");
        lines.Add("Type \"help <command>\" for details.");
        return string.Join(Environment.NewLine, lines);
    }

    private static string ShowCommandDetails(ICommand command)
    {
        var lines = new List<string>
        {
            command.Name,
            command.Description,
            "",
            "Usage:",
            $"  {command.Usage}"
        };
        if (command.Aliases is { Length: > 0 })
        {
            lines.Add("");
            lines.Add("Aliases:");
            lines.Add($"  {string.Join(", ", command.Aliases)}");
        }

        if (command.Args is not { Length: > 0 }) return string.Join(Environment.NewLine, lines);
        lines.Add("");
        lines.Add("Arguments:");
        foreach (var arg in command.Args)
        {
            var label = arg.Required ? $"<{arg.Name}>" : $"[{arg.Name}]";
            lines.Add($"  {label}");
            if (!string.IsNullOrWhiteSpace(arg.Description))
            {
                lines.Add($"    {arg.Description}");
            }
        }

        return string.Join(Environment.NewLine, lines);
    }
}