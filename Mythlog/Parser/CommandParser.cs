using Mythlog.Command;

namespace Mythlog.Parser;

public class CommandParser : ICommandParser
{
    private const string Prefix = "!";

    public CommandContext? Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        var trimmed = input.Trim();

        if (!IsCommand(trimmed))
        {
            return null;
        }

        var withoutPrefix = RemovePrefix(trimmed);

        if (IsEmpty(withoutPrefix))
        {
            return null;
        }

        var parts = SplitInput(withoutPrefix);

        return new CommandContext(Raw: input, Command: parts.Command, Args: parts.Args);
    }

    private static bool IsCommand(string input)
    {
        return input.StartsWith(Prefix);
    }

    private static string RemovePrefix(string input)
    {
        return input[Prefix.Length..].Trim();
    }

    private static bool IsEmpty(string input)
    {
        return input.Length == 0;
    }

    private static ParsedCommand SplitInput(string input)
    {
        var parts = input.Split((char[])null!, StringSplitOptions.RemoveEmptyEntries);
        return new ParsedCommand(Command: parts[0], Args: parts[1..].ToArray());
    }
}