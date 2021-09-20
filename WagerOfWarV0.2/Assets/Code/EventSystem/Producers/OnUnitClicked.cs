using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnUnitClicked : MonoBehaviour, IPointerClickHandler
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
        Debug.Log($"Clicked on: {gameObject.name}");
    }
}
