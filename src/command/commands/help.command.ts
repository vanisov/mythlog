import { BaseCommand } from "../command";
import { CommandRegistry } from "../command.registry";
import type { CommandContext, CommandResult } from "../command.types";

export class HelpCommand extends BaseCommand {
  readonly name = "help";
  readonly description = "Display all available commands and how to use them.";
  readonly usage = "help <command>";
  readonly args = [
    {
      name: "command",
      required: false,
      description: "Command to view detailed help for",
    },
  ];

  constructor(private readonly registry: CommandRegistry) {
    super();
  }

  execute(ctx: CommandContext): CommandResult {
    const selectedCommand = ctx.args[0];

    if (!selectedCommand) {
      return {
        success: true,
        output: this.showAllCommands(),
      };
    }

    const command = this.registry.get(selectedCommand);

    if (!command) {
      return {
        success: false,
        error: `Unknown command: ${selectedCommand}`,
      };
    }

    return {
      success: true,
      output: this.showCommandDetails(command),
    };
  }

  private showAllCommands(): string {
    const commands = this.registry.getAll();

    const lines = commands.map(c => `${c.name.padEnd(14)} ${c.description}`);

    return ["Available Commands:", "", ...lines, "", 'Type "help <command>" for details.'].join(
      "\n"
    );
  }

  private showCommandDetails(command: BaseCommand): string {
    const lines: string[] = [];

    lines.push(command.name);
    lines.push(command.description);
    lines.push("");
    lines.push("Usage:");
    lines.push(`  ${command.usage}`);

    if (command.aliases?.length) {
      lines.push("");

      lines.push("Aliases:");

      lines.push(`  ${command.aliases.join(", ")}`);
    }

    if (command.args?.length) {
      lines.push("");

      lines.push("Arguments:");

      for (const arg of command.args) {
        const label = arg.required ? `<${arg.name}>` : `[${arg.name}]`;

        lines.push(`  ${label}`);

        if (arg.description) {
          lines.push(`    ${arg.description}`);
        }
      }
    }

    return lines.join("\n");
  }
}
