using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Create Scriptable/Attack")]
public class Attack : Action
{
    [SerializeField] private Damage _damage;
    
    public override string GenDetails()
    {
        string s = "";
        s += $"Action Type: Attack\n";
        s += $"{_name}\n";
        s += $"{_description}\n";
        s += $"Damage: {_damage._damage}\n";
        s += $"Damage type: {_damage._dType}\n";
        s += $"Total Cooldown: {_currentCooldown}\n";
        s += $"Current Cooldown: {_currentCooldown}\n";
        return s;
    }
}
