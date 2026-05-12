export type State = {
  playerName: string;
  tick: number;
};

export type StateUpdater = (state: State) => State;
