using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage : Effect
{
    [SerializeField] public float _damage;
    [SerializeField] public DamageType _dType;
    protected UnitType _uType;

    public override void Start()
    {
        base.Start();
        _uType = _me._uType;
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
