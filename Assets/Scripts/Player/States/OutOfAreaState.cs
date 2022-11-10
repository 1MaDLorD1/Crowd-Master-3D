using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutOfAreaState : State
{
    public event UnityAction Died;

    private void OnEnable()
    {
        Died?.Invoke();
    }
}
