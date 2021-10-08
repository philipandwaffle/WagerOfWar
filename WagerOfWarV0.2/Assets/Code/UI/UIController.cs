using UnityEngine;

public class UIController : MonoBehaviour
{
    private Unit _currentUnit;
    [SerializeField] private UIActionController[] _uiACs;

    private void Start()
    {
        GameEvents.events._onTurnEnd += Clear;  
    }

    public void SetCurrentUnit(Unit unit)
    {
        this._currentUnit = unit;
        UpdateActionsUI();
    }

    private void Clear()
    {
        for (int i = 0; i < _uiACs.Length; i++)
        {
            _uiACs[i].UpdateAction(null);
        }
    }

    private void UpdateActionsUI()
    {
        for (int i = 0; i < _uiACs.Length; i++)
        {
            _uiACs[i].UpdateAction(_currentUnit._actions[i]);
        }
    }
}
