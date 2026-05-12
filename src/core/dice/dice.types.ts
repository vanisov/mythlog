export type DiceSides = 4 | 6 | 8 | 10 | 12 | 20;

export interface RollResult {
  value: number;
  sides: DiceSides;
}
