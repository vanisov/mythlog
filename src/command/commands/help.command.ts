import { BaseCommand } from '../command';
import type { CommandContext, CommandResult } from '../command.types';

export class HelpCommand extends BaseCommand {
  readonly name = 'help';

  execute(ctx: CommandContext): CommandResult {
    return {
      output: 'Help',
    };
  }
}
