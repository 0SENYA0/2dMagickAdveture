﻿using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected EnemyMovePresenter EnemyMovePresenter;
    [SerializeField] private State _targetState;

    public bool NeedTransit { get; protected set; }

    public State TargetState => _targetState;

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
