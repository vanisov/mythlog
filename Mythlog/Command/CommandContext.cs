namespace Mythlog.Command;

public record CommandContext(
    string Command,
    string Raw,
    string[] Args
    );