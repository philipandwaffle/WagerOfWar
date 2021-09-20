using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int _currentTeam = 1;
    private Board _board;

    private GameObject _trooper;
    private GameObject _riotTrooper;

    // Start is called before the first frame update
    void Start()
    {
        _trooper = Resources.Load<GameObject>("Prefabs/Units/Trooper");
        _riotTrooper = Resources.Load<GameObject>("Prefabs/Units/RiotTrooper");
        List<GameObject> emptyCol = new List<GameObject> { null, null, null, null };
        List<GameObject> trooperCol = new List<GameObject> { _trooper, _trooper, _trooper, _trooper };
        List<GameObject> riotTrooperCol = new List<GameObject> { _riotTrooper, _riotTrooper, _riotTrooper, _riotTrooper };

        List<List<GameObject>> board = new List<List<GameObject>> { emptyCol, trooperCol, riotTrooperCol, riotTrooperCol, trooperCol, emptyCol };
        _board = GetComponentInChildren<Board>();
        _board.PopulateBoard(board);
        _board.PlaceUnits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
