import { BaseCommand } from "../command";
import type { CommandContext, CommandResult, CommandRuntimeContext } from "../command.types";

export class RollCommand extends BaseCommand {
  readonly name = "roll";
  readonly description = "Roll a dice";
  readonly usage = "!roll <20 | 12 | 10 | 8 | 6 | 4>";

  execute(ctx: CommandContext, runtime: CommandRuntimeContext): CommandResult {
    const sides = Number(ctx.args[0]);

    if (!Number.isFinite(sides)) {
      return { success: false, output: "Invalid dice size" };
    }

    const result = runtime.dice.roll(sides as any);

    return {
      success: true,
      output: `You rolled a d${sides} and got ${result.value}`,
    };
  }
}
