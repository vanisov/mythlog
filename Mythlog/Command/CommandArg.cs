namespace Mythlog.Command;

public record CommandArg(
    string Name,
    bool Required = false,
    string? Description = null
    );
    