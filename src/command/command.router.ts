import { CommandParser } from "./command.parser";
import { CommandRegistry } from "./command.registry";
import type { CommandRuntimeContext } from "./command.types";
import { HelpCommand, LookCommand, RollCommand } from "./commands";

export class CommandRouter {
  private readonly parser: CommandParser;
  private readonly registry: CommandRegistry;

  constructor() {
    this.parser = new CommandParser();
    this.registry = new CommandRegistry();

    this.registerCommands();
  }

  route(input: string, ctx: CommandRuntimeContext) {
    const context = this.parser.parse(input);

    if (!context) {
      return null;
    }

    const command = this.registry.get(context.command);

    if (!command) {
      return {
        output: `Unknown command: ${context.command}`,
      };
    }

    return command.execute(context, ctx);
  }

  private registerCommands(): void {
    this.registry.register(new LookCommand());
    this.registry.register(new HelpCommand(this.registry));
    this.registry.register(new RollCommand());
  }
}
