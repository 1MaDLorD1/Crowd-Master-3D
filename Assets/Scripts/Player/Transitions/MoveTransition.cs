using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : PlayerTransition
{
    protected override void OnEnable()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            NeedTransit = true;
    }
}
