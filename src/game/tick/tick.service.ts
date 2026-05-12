import type { TickListener } from "./tick.types";

export class TickService {
  private listeners: TickListener[] = [];

  public onTick(listener: TickListener): void {
    this.listeners.push(listener);
  }

  public tick(delta = 1): void {
    for (const listener of this.listeners) {
      listener(delta);
    }
  }
}
