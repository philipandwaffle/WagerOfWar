using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    [SerializeField] public Text _text;
    private Unit _targetUnit;
    private Attack _selectedAttack;
    

    void Start()
    {
        GameEvents.events._setSelectedAttack += SetSelectedAttack;
        GameEvents.events._setTargetUnit += SetTargetUnit;
        GameEvents.events._performAttack += PerformAttack;
    }

    private void SetSelectedAttack(Attack a)
    {
        this._selectedAttack = a;
        UpdateText();
    }
    private void SetTargetUnit(Unit u)
    {
        this._targetUnit = u;
        UpdateText();
    }
    public void PerformAttack()
    {
        if (_selectedAttack != null && _targetUnit != null)
        {
            _targetUnit.Damage(_selectedAttack);
            Clear();
        }
    }
    private void UpdateText()
    {
        string s = "";
        string attackName = _selectedAttack != null ? _selectedAttack._name : "Not selected";
        string unitName = _targetUnit != null ? _targetUnit.name : "Not selected";
        s += $"Current Team: {GameController._currentTeam}\n";
        s += $"Selected Attack: {attackName}\n";
        s += $"Target Unit: {unitName}\n";
        _text.text = s;
    }

    private void Clear()
    {
        _targetUnit = null;
        _selectedAttack = null;
        UpdateText();
    }
}
