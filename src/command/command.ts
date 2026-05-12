import type {
  CommandArg,
  CommandContext,
  CommandResult,
  CommandRuntimeContext,
} from "./command.types";

export abstract class BaseCommand {
  abstract readonly name: string;
  abstract readonly description: string;
  abstract readonly usage: string;

  readonly aliases?: string[];
  readonly args?: CommandArg[];

  abstract execute(ctx: CommandContext, runtime: CommandRuntimeContext): CommandResult;
}
