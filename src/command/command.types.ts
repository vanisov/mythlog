import type { Dice } from "../core";
import type { TickService } from "../game";
import type { StateStore } from "../state";

export type CommandContext = {
  command: string;
  raw: string;
  args: string[];
};

export interface CommandRuntimeContext {
  dice: Dice;
  store: StateStore;
  tick: TickService;
}

export type CommandResult = {
  success: boolean;
  output?: string;
  error?: string;
};

export type ParsedCommand = {
  command: string;
  args: string[];
};

export type CommandHandler = (args: string[], ctx: CommandContext) => CommandResult;

export type CommandArg = {
  name: string;
  required?: boolean;
  description?: string;
};
