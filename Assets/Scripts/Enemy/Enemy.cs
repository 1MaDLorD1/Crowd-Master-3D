using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class Enemy : StateMachine, IDamageable
{
    [SerializeField] private BrokenState _brokenState;
    [SerializeField] private HealthContainer _healthContainer;

    private EnemyState _currentState;
    private float _minDamage;

    public Player Player { get; private set; }

    public event UnityAction<Enemy> Died;

    private void OnEnable()
    {
        _healthContainer.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died?.Invoke(this);
    }

    protected override void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Player = FindObjectOfType<Player>();
    }

    protected override void Start()
    {
        _currentState = (EnemyState)_firstState;
        _currentState.Enter(_rigidbody, _animator, Player);
    }

    protected override void Update()
    {
        if (_currentState == null)
            return;

        EnemyState nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(EnemyState nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_rigidbody, _animator, Player);
    }

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        if(force > _minDamage && _currentState != _brokenState)
        {
            _healthContainer.TakeDamage((int)force);
            Transit(_brokenState);
            _brokenState.ApplyDamage(rigidbody, force);
            return true;
        }

        return false;
    }
}
