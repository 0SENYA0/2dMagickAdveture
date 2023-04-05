using UnityEngine;

public class StandartStateMachine : MonoBehaviour
{
    [SerializeField] State _firstState;
    
    private State _state;

    private void Start()
    {
        _state = _firstState;
        _state.Enter();
    }

    private void Update()
    {
        if (_state == null)
        {
            return;
        }

        var nextState = _state.GetNext();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(State nextState)
    {
        if (_state != null)
        {
            _state.Exit();
        }

        _state = nextState;

        if (_state != null)
        {
            _state.Enter();
        }
    }
}
