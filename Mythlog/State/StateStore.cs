namespace Mythlog.State;

public class StateStore(State initialState)
{

    private State _state =  initialState;

    public State Get() => _state;
    
    public void Update(StateUpdater updater)
    {
        _state = updater(_state);
    }
}