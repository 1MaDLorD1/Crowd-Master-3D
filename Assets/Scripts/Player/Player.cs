using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(HealthContainer))]
public class Player : StateMachine
{
    [SerializeField] private TMP_Text _text;

    private HealthContainer _health;

    public event UnityAction Damaged;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
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
        base.Start();
    }

    protected override void Update()
    {
        _text.text = $"Health: {_health.Health}";
        base.Update();
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage((int)damage);
    }
}
