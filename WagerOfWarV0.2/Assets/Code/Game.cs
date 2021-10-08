using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int _currentTeam = 1;
    public static Board _board;

    private GameObject _trooper;
    private GameObject _riotTrooper;

    // Start is called before the first frame update
    private void Start()
    {
        _trooper = Resources.Load<GameObject>("Prefabs/Units/Trooper");
        _riotTrooper = Resources.Load<GameObject>("Prefabs/Units/RiotTrooper");
        List<GameObject> emptyCol1 = new List<GameObject> { null, null, null, null };
        List<GameObject> trooperCol1 = new List<GameObject> { _trooper, _trooper, _trooper, _trooper };
        List<GameObject> riotTrooperCol1 = new List<GameObject> { _riotTrooper, _riotTrooper, _riotTrooper, _riotTrooper };
        List<GameObject> riotTrooperCol2 = new List<GameObject> { _riotTrooper, _riotTrooper, _riotTrooper, _riotTrooper };
        List<GameObject> trooperCol2 = new List<GameObject> { _trooper, _trooper, _trooper, _trooper };
        List<GameObject> emptyCol2 = new List<GameObject> { null, null, null, null };

        List<List<GameObject>> board = new List<List<GameObject>> { emptyCol1, trooperCol1, riotTrooperCol1, riotTrooperCol2, trooperCol2, emptyCol2};
        _board = GetComponentInChildren<Board>();
        _board.PopulateBoard(board);
        _board.PlaceUnits();
    }

    public static void NextTurn()
    {
        _currentTeam = _currentTeam == 1 ? 2 : 1;
        _board.SpendEffects();
        OnTurnEnd.EndTurn();
    }
}
