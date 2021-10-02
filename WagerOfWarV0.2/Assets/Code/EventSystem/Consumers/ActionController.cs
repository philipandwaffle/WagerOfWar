using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _details;
    public Unit _targetUnit { private set; get; }
    public Action _selectedAction { private set; get; }

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
            $"Action: {_selectedAction?.name}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    private void PerformAction()
    {
        
    }
}