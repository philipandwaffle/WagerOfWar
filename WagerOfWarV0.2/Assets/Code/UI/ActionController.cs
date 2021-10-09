using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _details;
    private Unit _targetUnit;
    private Action _selectedAction;

    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.events._onActionClick += SetSelectedAction;
        GameEvents.events._onTargetClick += SetTargetUnit;
    }

    private void SetTargetUnit(Unit u)
    {
        this._targetUnit = u;
        UpdateText();
    }
    private void SetSelectedAction(Action a)
    {
        this._selectedAction = a;
        UpdateText();
    }

    private void UpdateText()
    {
        _details.text = $"Targeting: {_targetUnit?.name}\n" +
            $"Action: {_selectedAction?.name}\n" +
            $"Current team: {Game._currentTeam}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PerformAction();
    }

    private void PerformAction()
    {
        if (_targetUnit != null && _selectedAction != null)
        {
            Game._board.ApplyEffects(_selectedAction, _targetUnit);
            Game.NextTurn();
            _targetUnit = null;
            _selectedAction = null;
            UpdateText();
        }
    }
}