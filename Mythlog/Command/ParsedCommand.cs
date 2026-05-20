namespace Mythlog.Command;

public record ParsedCommand(
    string Command,
    string[] Args
    );