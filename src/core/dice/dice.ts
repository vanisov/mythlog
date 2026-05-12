import type { DiceSides, RollResult } from "./dice.types";

export class Dice {
  /**
   * Rolls a dice with the given number of sides and returns the result.
   *
   * @param sides The number of sides on the dice to roll
   * @returns A structured result containing the rolled value and dice type
   */
  roll(sides: DiceSides): RollResult {
    return {
      value: this.randomNum(sides),
      sides,
    };
  }

  private randomNum(sides: number): number {
    return Math.floor(Math.random() * sides) + 1;
  }
}
