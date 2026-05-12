import { BaseCommand } from '../command';
import type { CommandResult } from '../command.types';

export class LookCommand extends BaseCommand {
  readonly name = 'look';

  execute(): CommandResult {
    return {
      output: 'You see darkness surrounding you...',
    };
  }
}
