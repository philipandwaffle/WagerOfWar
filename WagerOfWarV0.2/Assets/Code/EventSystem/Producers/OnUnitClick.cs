using UnityEngine;
using UnityEngine.EventSystems;

public class OnUnitClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public bool _debug;
    private Unit _me;

    private void Start()
    {
        _me = gameObject.GetComponent<Unit>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_me == null) { return; }
        if (_debug) { LogDebug(); }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_me._team != Game._currentTeam) { GameEvents.events.OnTargetClick(_me); }   //if target
            if (_me._team == Game._currentTeam) { GameEvents.events.OnOwnUnitClick(_me); }  //if owned
        }
    }
    private void LogDebug()
    {
        string msg = $"Unit clicked: {gameObject.name}";
        if (_me._team != Game._currentTeam) { msg += "\tSending as target"; }   //if target
        if (_me._team == Game._currentTeam) { msg += "\tSending as owned"; }  //if owned
        Debug.Log(msg);
    }
}
