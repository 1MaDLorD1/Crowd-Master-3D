using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : EnemyState
{
    private void OnEnable()
    {
        Animator.SetTrigger("isWaving");
    }

    private void OnDisable()
    {
        Animator.ResetTrigger("isWaving");
    }
}
