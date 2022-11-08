using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    //[SerializeField] private EnemyTransition[] _enemyTransitions;

    public Player Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator, Player player)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                ((EnemyTransition)transition).Init(Player);
            }
        }
    }

    public new EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return (EnemyState)transition.TargetState;
            }
        }

        return null;
    }
}
