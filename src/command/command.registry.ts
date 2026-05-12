import type { BaseCommand } from './command';

export class CommandRegistry {
  private readonly commands = new Map<string, BaseCommand>();

  register(command: BaseCommand): void {
    this.commands.set(command.name, command);
  }

  get(name: string): BaseCommand | undefined {
    return this.commands.get(name);
  }
}
