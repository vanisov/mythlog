using Mythlog.Command;

namespace Mythlog.Parser;

public class CommandParser : ICommandParser
{
    private const string Prefix = "!";

    public ParsedCommand? Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        var trimmed = input.Trim();

        if (!trimmed.StartsWith(Prefix))
        {
            return null;
        }

        var withoutPrefix = trimmed[1..];

        if (string.IsNullOrWhiteSpace(withoutPrefix))
        {
            return null;
        }

        var split = withoutPrefix.Split(
            "",
            StringSplitOptions.RemoveEmptyEntries
        );

        var commandName = split[0].ToLowerInvariant();

        var args = split.Skip(1).ToList();

        return new ParsedCommand(
            commandName,
            args,
            trimmed
        );
    }

    private bool IsCommand(string input)
    {
        return input.StartsWith(Prefix);
    }

    private string RemovePrefix(string input)
    {
        return input[Prefix.Length..].Trim();
    }
}