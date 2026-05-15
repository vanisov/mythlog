using Mythlog.Command;
using Mythlog.Command.Commands;
using Mythlog.Core.Dice;
using Mythlog.Parser;
using Mythlog.State;
using Mythlog.Tick;

var store = new StateStore(
    new State(PlayerName: "Player", Tick: 0)
);

var tick = new TickService();

var runtime = new AppRuntimeContext(
    new Dice(),
    store,
    tick
);

var registry = new CommandRegistry();

var parser = new CommandParser();

tick.OnTick(_ =>
    store.Set(state =>
        state with { Tick = state.Tick + 1 }
    )
);

registry.Register(new RollCommand());
registry.Register(new HelpCommand(registry));

if (args.Length > 0)
{
    return await ExecuteCommand(
        string.Join(' ', args),
        parser,
        registry,
        runtime
    );
}

Console.WriteLine("Mythlog");
Console.WriteLine("Type \"help\" for commands or \"exit\" to quit.");

while (true)
{
    Console.Write("> ");

    var input = Console.ReadLine();

    if (input is null || IsExitCommand(input))
    {
        return 0;
    }

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    await ExecuteCommand(
        input,
        parser,
        registry,
        runtime
    );

    tick.Tick();
}

static async Task<int> ExecuteCommand(
    string raw,
    ICommandParser parser,
    CommandRegistry registry,
    ICommandRuntimeContext runtime
)
{
    var parsed = parser.Parse(raw);

    if (parsed is null)
    {
        Console.Error.WriteLine("Invalid command.");
        return 1;
    }

    var command = registry.Get(parsed.Name);

    if (command is null)
    {
        Console.Error.WriteLine(
            $"Unknown command: {parsed.Name}"
        );

        Console.Error.WriteLine(
            "Type \"help\" for commands."
        );

        return 1;
    }

    var context = new CommandContext(
        parsed.Name,
        parsed.Raw,
        parsed.Args.ToArray()
    );

    var result = await command.Execute(
        context,
        runtime
    );

    if (!string.IsNullOrWhiteSpace(result.Output))
    {
        var output =
            result.Success
                ? Console.Out
                : Console.Error;

        output.WriteLine(result.Output);
    }

    return result.Success ? 0 : 1;
}

static bool IsExitCommand(string input)
{
    return input.Equals(
               "exit",
               StringComparison.OrdinalIgnoreCase
           )
           || input.Equals(
               "quit",
               StringComparison.OrdinalIgnoreCase
           );
}

internal sealed class AppRuntimeContext(
    Dice dice,
    StateStore store,
    TickService tick
) : ICommandRuntimeContext
{
    public Dice Dice { get; } = dice;

    public StateStore Store { get; } = store;

    public TickService Tick { get; } = tick;
}