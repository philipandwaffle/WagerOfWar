using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameController : MonoBehaviour
{
    [SerializeField] public Board _board;

    [SerializeField] public GameObject riot;
    [SerializeField] public GameObject trooper;

    [SerializeField] public static int _currentTeam;

    public void Start()
    {
        _currentTeam = 1;
        GameEvents.events._nextPlayer += NextPlayer;
        List<GameObject> riotCol = new List<GameObject> { riot, riot, riot, riot };
        List<GameObject> trooperCol = new List<GameObject> { trooper, trooper, trooper, trooper };
        List<GameObject> nullCol = new List<GameObject> { null, null, null, null };

        List<List<GameObject>> team = new List<List<GameObject>> { riotCol, trooperCol, nullCol };

        _board.PopulateBoard(team,team);
        _board.PlaceUnits();
    }

    private void NextPlayer()
    {
        _currentTeam = _currentTeam == 1 ? 2 : 1;
    }
}
