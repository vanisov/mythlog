import type { CommandContext, ParsedCommand } from './command.types.js';

export class CommandParser {
  private static readonly PREFIX = '!';

  parse(input: string): CommandContext | null {
    const trimmed = input.trim();

    if (!this.isCommand(trimmed)) {
      return null;
    }

    const withoutPrefix = this.removePrefix(trimmed);

    if (this.isEmpty(withoutPrefix)) {
      return null;
    }

    const parts = this.splitInput(withoutPrefix);

    return {
      raw: input,
      ...parts,
    };
  }

  private isCommand(input: string): boolean {
    return input.startsWith(CommandParser.PREFIX);
  }

  private removePrefix(input: string): string {
    return input.slice(CommandParser.PREFIX.length).trim();
  }

  private isEmpty(input: string): boolean {
    return input.length === 0;
  }

  private splitInput(input: string): ParsedCommand {
    const parts = input.split(/\s+/).filter(Boolean);

    return {
      command: parts[0],
      args: parts.slice(1),
    };
  }
}
