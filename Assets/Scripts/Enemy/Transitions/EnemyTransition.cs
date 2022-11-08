using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : Transition
{
    //[SerializeField] private EnemyState _targetState;

    //public new EnemyState TargetState => (EnemyState)_targetState;

    protected Player Player { get; private set; }

    public void Init(Player player)
    {
        Player = player;
    }
}
