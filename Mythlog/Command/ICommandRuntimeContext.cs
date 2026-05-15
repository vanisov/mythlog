using Mythlog.Core.Dice;
using Mythlog.Tick;
using Mythlog.State;

namespace Mythlog.Command;

public interface ICommandRuntimeContext
{
    Dice Dice { get; }
    StateStore Store { get; }
    TickService Tick { get; }
}