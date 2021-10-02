using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMessenger
{
    public static void Send(string s)
    {
        GameEvents.events.SendConsoleMessage(s);
    } 
}
