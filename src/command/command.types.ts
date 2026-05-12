export type CommandContext = {
  command: string;
  raw: string;
  args: string[];
};

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
