import type { State, StateUpdater } from "./state.types";

export class StateStore {
  private _state: State;

  constructor(initialState: State) {
    this._state = initialState;
  }

  public get state(): Readonly<State> {
    return this._state;
  }

  public set(updater: StateUpdater): void {
    this._state = updater(this._state);
  }
}
