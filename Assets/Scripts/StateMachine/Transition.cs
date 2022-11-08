using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected State _targetState;

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
