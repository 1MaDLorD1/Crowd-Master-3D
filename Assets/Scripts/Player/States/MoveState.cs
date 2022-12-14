using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
        _staminaAccumulator.StartAccumulate();
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
        Animator.SetFloat("Run", 0);
    }

    private void OnDirectionChanged(Vector2 direction)
    {
        Rigidbody.velocity = new Vector3(-direction.y, 0, direction.x) * _speedRatio;
        if (Rigidbody.velocity.magnitude > _maxSpeed)
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;

        if (Rigidbody.velocity.magnitude != 0)
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
    }

    private void Update()
    {
        Animator.SetFloat("Run", Rigidbody.velocity.magnitude / _maxSpeed);
    }
}
