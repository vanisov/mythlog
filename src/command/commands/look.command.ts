import { BaseCommand } from "../command";
import type { CommandResult } from "../command.types";

export class LookCommand extends BaseCommand {
  readonly name = "look";
  readonly description = "observe";
  readonly usage = "look <direction>";

  execute(): CommandResult {
    return {
      success: true,
      output: "You see darkness surrounding you...",
    };
  }
}
