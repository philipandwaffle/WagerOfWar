using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageOverTime : Damage
{
    [SerializeField] private int _ticksLeft;

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
