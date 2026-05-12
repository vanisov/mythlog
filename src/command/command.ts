import type { CommandContext, CommandResult } from './command.types';

export abstract class BaseCommand {
  abstract readonly name: string;

  abstract execute(ctx: CommandContext): CommandResult;
}
