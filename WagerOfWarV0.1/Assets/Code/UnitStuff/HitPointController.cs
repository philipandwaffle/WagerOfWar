using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitPointController
{
    [SerializeField] public float _health;
    [SerializeField] public float _armour;
    [SerializeField] public float _modifier;
    [SerializeField] public bool _isDead = false;

    public HitPointController(float health, float armour = 0, float modifier = 0)
    {
        this._health = health;
        this._armour = armour;
        this._modifier = modifier;
    }

    public bool Damage(float damage)
    {
        _health -= DamageArmour(damage);
        _isDead = _health < 0; 
        if (_isDead) { _health = 0; }

        return _isDead;        //returns if the health is 0
    }

    private float DamageArmour(float d)
    {
        if (_armour == 0 ) { return d; }
        float effectiveHealth = _armour * (1 + _modifier);
        if (effectiveHealth > d) 
        { 
            _armour -= d * (1 - _modifier);
            return 0;
        }
        else
        {
            float carryOver = effectiveHealth - d;
            _armour = 0;
            return carryOver;
        }
    }
}
