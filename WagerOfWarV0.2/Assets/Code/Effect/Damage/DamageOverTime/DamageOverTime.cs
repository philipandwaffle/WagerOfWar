using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/DOT")]
[System.Serializable]
public class DamageOverTime : Damage
{
    [SerializeField] private int _ticksLeft;
    public override void Execute(Unit u)
    {
        u.Damage(_damage);
        --_ticksLeft;
        if(_ticksLeft == 0) { _spent = true; }
    }
}
