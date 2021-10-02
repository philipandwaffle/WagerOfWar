using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Create Scriptable/Attack")]
public class Attack : Action
{
    public override string GenDetails()
    {
        string s = "";
        s += $"Action Type: Attack\n";
        s += $"{_name}\n";
        s += $"{_description}\n";
        foreach (Effect e in _effects)
        {
            s += $"{e._name}: {e._description}";
        }
        s += $"Total Cooldown: {_currentCooldown}\n";
        s += $"Current Cooldown: {_currentCooldown}\n";
        return s;
    }
}
