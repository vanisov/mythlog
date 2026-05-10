export type CommandContext = {
  command: string;
  raw: string;
  args: string[];
};

export type CommandResult = {
  output: string;
};

export type ParsedCommand = {
  command: string;
  args: string[];
};

export type CommandHandler = (args: string[], ctx: CommandContext) => CommandResult;
