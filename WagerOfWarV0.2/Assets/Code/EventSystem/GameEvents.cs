using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents events;

    public void Awake()
    {
        events = this;
    }

    public delegate void OnTurnEndDelegate();
    public event OnTurnEndDelegate _onTurnEnd;
    public void OnTurnEnd()
    {
        _onTurnEnd?.Invoke();
    }

    //for when a unit that you own is clicked and sent to the UI
    public delegate void OnOwnUnitClickDelegate(Unit u);
    public event OnOwnUnitClickDelegate _onOwnUnitClicked;
    public void OnOwnUnitClick(Unit u)
    {
        _onOwnUnitClicked?.Invoke(u);
    }

    //for when a unit that you're targeting is clicked and sent to the action manager
    public delegate void OnTargetClickDelegate(Unit u);
    public event OnTargetClickDelegate _onTargetClick;
    public void OnTargetClick(Unit u)
    {
        _onTargetClick?.Invoke(u);
    }
    //for when an action is selected and is sent to the action manager
    public delegate void OnActionClickDelegate(Action a);
    public event OnActionClickDelegate _onActionClick;
    public void OnActionClick(Action a)
    {
        _onActionClick?.Invoke(a);
    }

    //for when console message is sent to the console
    public delegate void SendConsoleMessageDelegate(string s);
    public event SendConsoleMessageDelegate _SendConsoleMessage;
    public void SendConsoleMessage(string s)
    {
        _SendConsoleMessage?.Invoke(s);
    }
}
