import { CommandParser } from './command.parser';
import { CommandRegistry } from './command.registry';
import { LookCommand } from './commands/look.command';

export class CommandRouter {
  private readonly parser: CommandParser;
  private readonly registry: CommandRegistry;

  constructor() {
    this.parser = new CommandParser();
    this.registry = new CommandRegistry();

    this.registerCommands();
  }

  route(input: string) {
    const context = this.parser.parse(input);

    if (!context) {
      return null;
    }

    const command = this.registry.get(context.command);

    if (!command) {
      return {
        output: 'Unknown command.',
      };
    }

    return command.execute(context);
  }

  private registerCommands(): void {
    this.registry.register(new LookCommand());
  }
}
