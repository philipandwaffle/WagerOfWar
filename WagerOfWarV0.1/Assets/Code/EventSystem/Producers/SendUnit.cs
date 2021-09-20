using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SendUnit : MonoBehaviour, IPointerClickHandler
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

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_me._team != GameController._currentTeam) { GameEvents.events.SetTargetUnit(_me); }
            if (_me._team == GameController._currentTeam) { GameEvents.events.SetUnitAttacks(_me); }
        }
        if (_debug) { LogDebug(); }
    }
    private void LogDebug()
    {
        Debug.Log($"Clicked on: {gameObject.name}");
    }
}
