using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/Damage")]
[System.Serializable]
public class Damage : Effect
{
    [SerializeField] public float _damage;
    [SerializeField] public DamageType _dType;
    protected UnitType _uType;

    public override void Execute(Unit u)
    {
        throw new System.NotImplementedException();
    }
}
