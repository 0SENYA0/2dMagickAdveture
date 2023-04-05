using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] protected EnemyMoveController EnemyMoveController;

    public void Enter()
    {
        enabled = true;

        foreach (Transition transition in _transitions)
        {
            transition.enabled = true;
        }
    }

    public State GetNext()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}
