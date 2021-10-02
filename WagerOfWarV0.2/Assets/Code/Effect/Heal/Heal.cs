using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/Heal")]
[System.Serializable]
public class Heal : Effect
{
    private float _health;
    private float _armour;
        
    public override void Execute(Unit u)
    {
        throw new System.NotImplementedException();
    }
}
