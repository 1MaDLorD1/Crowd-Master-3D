using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthContainer))]
public class Player : StateMachine
{
    [SerializeField] private OutOfAreaState _outOfAreaState;
    [SerializeField] private float _fallDistance;

    private HealthContainer _health;

    public event UnityAction Damaged;

    public event UnityAction<int> HealthUpdated;

    private void OnEnable()
    {
        _health.Died += OnDied;
        _outOfAreaState.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _outOfAreaState.Died -= OnDied;
    }

    private void OnDied()
    {
        enabled = false;
        _animator.SetTrigger("isDead");
    }

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<HealthContainer>();
    }

    protected override void Start()
    {
        HealthUpdated?.Invoke(_health.Health);
        base.Start();
    }

    protected override void Update()
    {
        OnPlatform();
        base.Update();
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage((int)damage);
        HealthUpdated?.Invoke(_health.Health);
    }

    private void OnPlatform()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);

        if (Physics.Raycast(ray, _fallDistance) == false)
        {
            Transit(_outOfAreaState);
        }
    }
}
