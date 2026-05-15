using Mythlog.Command.Commands;

namespace Mythlog.Command;

public class CommandRegistry
{
    private readonly Dictionary<string, ICommand> _commands = new();

    public void Register(ICommand command)
    {
        _commands.Add(command.Name, command);
        foreach (var alias in command.Aliases)
        {
            _commands[alias] = command;
        }
    }

    public ICommand? Get(string name)
    {
        return _commands.GetValueOrDefault(name);
    }

    public List<ICommand> GetAll()
    {
        return _commands.Values.Distinct().ToList();
    }
}