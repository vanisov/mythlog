using Mythlog.Command;

namespace Mythlog.Parser;

public interface ICommandParser
{
    ParsedCommand? Parse(string input);
}