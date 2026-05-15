namespace Mythlog.Command.Commands;

using Mythlog.Core.Dice;

public class RollCommand : BaseCommand
{
    public override string Name =>
        "roll";

    public override string Description =>
        "Roll a dice";

    public override string Usage =>
        "roll <d4 | d6 | d8 | d12 | d16 | d20>";

    public override Task<CommandResult> Execute(CommandContext ctx,
        ICommandRuntimeContext runtime)
    {
        if (ctx.Args.Length == 0)
        {
            return Task.FromResult(new CommandResult(Success: false,
                Output: "Missing dice size"));
        }

        if (!int.TryParse(ctx.Args[0],
                out var sidesValue))
        {
            return Task.FromResult(new CommandResult(Success: false,
                Output: "Invalid dice size"));
        }

        if (!Enum.IsDefined(typeof(DiceSides),
                sidesValue))
        {
            return Task.FromResult(new CommandResult(Success: false,
                Output: "Unsupported dice. Use 4, 6, 8, 12, 16, or 20."));
        }

        var sides = (DiceSides)sidesValue;
        var result = Dice.Roll(sides);
        return Task.FromResult(new CommandResult(Success: true,
            Output: $"You rolled a d{sidesValue} and got {result.Value}"));
    }
}