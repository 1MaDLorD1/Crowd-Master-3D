using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] protected State _firstState;

    private State _currentState;
    protected Rigidbody _rigidbody;
    protected Animator _animator;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);
    }

    protected virtual void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    protected void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_rigidbody, _animator);
    }
}
