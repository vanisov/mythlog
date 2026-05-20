using System.Security.Cryptography;

namespace Mythlog.Dice;

public class Dice
{
    /// <summary>
    /// Rolls a die with the given number of sides and returns the result.
    /// </summary>
    /// <param name="sides">The number of sides on the dice to roll</param>
    /// <returns>A structured result containing the rolled value and dice type</returns>
    public static RollResult Roll(DiceSides sides)
    {
        return new RollResult(
            Value: RandomNumberGenerator.GetInt32(1, (int)sides + 1),
            Sides: sides
        );
    }
}