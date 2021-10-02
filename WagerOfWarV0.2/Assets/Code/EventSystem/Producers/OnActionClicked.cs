using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnActionClicked : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public bool _debug;

    public void OnPointerClick(PointerEventData eventData)
    {
        Action a = GetComponent<UIActionController>()._action;
        if (_debug) { LogDebug(a); }
        GameEvents.events.OnActionClick(a);
    }

    private void LogDebug(Action a)
    {
        Debug.Log($"sent action {a.ToString()}");
    }
}
