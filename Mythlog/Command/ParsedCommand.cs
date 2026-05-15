namespace Mythlog.Command;

public record ParsedCommand(
    string Name,
    List<string> Args,
    string Raw
    );