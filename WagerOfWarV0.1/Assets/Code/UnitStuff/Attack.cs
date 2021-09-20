using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack 
{
    public string _name;
    public string _description;
    public float _damage;
    public AttackType _type;
    public int _range;
    public int _cooldown;
    public string _sprite;
    public bool _checkLOS;
    public enum AttackType { circle, cross, diagonal, horizontal, vertical };

    public Attack(string name, string description, float damage, AttackType type, int range, int cooldown, string sprite, bool checkLOS)
    {
        this._name = name;
        this._description = description;
        this._damage = damage;
        this._type = type;
        this._range = range;
        this._cooldown = cooldown;
        this._sprite = sprite;
        this._checkLOS = checkLOS;
    }
}
