using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTurnEnd
{
    public static void EndTurn()
    {
        GameEvents.events.OnTurnEnd();
    }
}
