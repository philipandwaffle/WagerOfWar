using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit : MonoBehaviour
{
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    [SerializeField] public Action[] _actions;
    [SerializeField] public HitPointController _hpc;
    private HealthBarController _hbc;
    [SerializeField] public UnitType _uType;
    [SerializeField] public int _team;

    private void Start()
    {
        _hbc = GetComponent<HealthBarController>();
        _hbc.InitBar(_hpc._health, _hpc._armour);
    }

    public void Damage(float damage)
    {
        if (_hpc.Damage(damage)) { Destroy(gameObject); }
        _hbc.UpdateBar(_hpc._health, _hpc._armour);
    }
}
