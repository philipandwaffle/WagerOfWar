using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Unit _currentUnit;
    [SerializeField] private UIActionController[] _uiActionControllers;

    public void SetCurrentUnit(Unit unit)
    {
        this._currentUnit = unit;
        UpdateActionsUI();
    }

    private void UpdateActionsUI()
    {
        for (int i = 0; i < _uiActionControllers.Length; i++)
        {
            _uiActionControllers[i].UpdateAction(_currentUnit._actions[i]);
        }
    }
}
