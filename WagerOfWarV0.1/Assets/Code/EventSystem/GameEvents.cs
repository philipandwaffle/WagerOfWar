using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents events;
    // Start is called before the first frame update
    void Awake()
    {
        events = this;    
    }

    public event Action<Unit> _setUnitAttacks;
    public void SetUnitAttacks(Unit u)
    {
        _setUnitAttacks?.Invoke(u);
    }

    public event Action<Attack> _setSelectedAttack;
    public void SetSelectedAttack(Attack a)
    {
        _setSelectedAttack?.Invoke(a);
    }

    public event Action<Unit> _setTargetUnit;
    public void SetTargetUnit(Unit u)
    {
        _setTargetUnit?.Invoke(u);
    }

    public event Action _performAttack;
    public void PerformAttack()
    {
        _performAttack?.Invoke();
    }

    public event Action _nextPlayer;
    public void NextPlayer()
    {
        _nextPlayer?.Invoke();
    }

}
