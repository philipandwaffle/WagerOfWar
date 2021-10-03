using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/Action")]
[System.Serializable]
public class Action : ScriptableObject
{
    public string _name;
    public string _description;
    public int _cooldown;
    public int _currentCooldown;
    public ActionType _aType;
    public int _range;
    public string _sprite;
    public bool _checkLOS;
    public List<Effect> _effects;
    public bool _targetFirendly;

    public virtual string GenDetails()
    {
        string s = "";
        s += $"Action Type: Action";
        s += $"{_name}\n";
        s += $"{_description}\n";
        s += $"Total Cooldown: {_currentCooldown}\n";
        s += $"Current Cooldown: {_currentCooldown}\n";
        return s;
    }

    public override string ToString()
    {
        return $"{_name}";
    }

    public virtual void SetEffectFalloff(float f)
    {
        foreach (Effect e in _effects)
        {
            e._falloffModifier = f;
        }
    }
}
