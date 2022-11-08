using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public bool ApplyDamage(Rigidbody rigidbody, float force);
}