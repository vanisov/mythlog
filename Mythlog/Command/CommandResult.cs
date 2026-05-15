namespace Mythlog.Command;

public record CommandResult(
    bool Success,
    string? Output = null
    );