using Mythlog.Command;

namespace Mythlog.Parser;

public interface ICommandParser
{
    CommandContext? Parse(string input);
}