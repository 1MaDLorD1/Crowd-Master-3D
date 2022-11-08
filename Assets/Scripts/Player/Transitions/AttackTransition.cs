using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : PlayerTransition
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            NeedTransit = true;
    }
}
