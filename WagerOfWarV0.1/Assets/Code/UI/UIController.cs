using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Unit _currentUnit;

    [SerializeField] public UIAttackController _attack1;
    [SerializeField] public UIAttackController _attack2;
    [SerializeField] public UIAttackController _attack3;

    public void SetCurrentUnit(Unit u)
    {
        this._currentUnit = u;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _attack1.UpdateAttack(_currentUnit._attacks[0]);
        _attack2.UpdateAttack(_currentUnit._attacks[1]);
        _attack3.UpdateAttack(_currentUnit._attacks[2]);
    }
}
