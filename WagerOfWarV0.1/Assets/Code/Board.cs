using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Board : MonoBehaviour
{
    public List<List<GameObject>> _team1;
    public List<List<GameObject>> _team2;
    [SerializeField] public float _spacing;

    private bool _isTeam1Turn = true;
    private Unit _selectedUnit;
    private Unit _targetedUnit;

    public void PopulateBoard(List<List<GameObject>> team1, List<List<GameObject>> team2)
    {
        this._team1 = team1;
        this._team2 = team2;
    }
        
    public void PlaceUnits()
    {
        List<List<GameObject>> board = new List<List<GameObject>>();
        for (int x = _team1.Count-1; x >= 0; x--)
        {
            board.Add(_team1[x]);
        }
        for (int x = 0; x < _team2.Count; x++)
        {
            board.Add(_team2[x]);
        }

        for (int x = 0; x < board.Count; x++)
        {
            for (int y = 0; y < board[x].Count; y++)
            {
                if (board[x][y] != null)
                {                    
                    board[x][y] = Instantiate(board[x][y]);
                    SetUpUnit(board[x][y], x, y);                    
                }
            }
        }
    }
    private void SetUpUnit(GameObject g, int x, int y)
    {
        g.transform.SetParent(gameObject.transform);
        g.transform.position = new Vector3(x * _spacing, y * _spacing, 0);
        g.name = $"{x},{y}:\t{g.GetComponent<Unit>()._name}";
        g.GetComponent<SpriteController>().SetFlipX(x >= _team1.Count);
        g.GetComponent<Unit>()._team = x >= _team1.Count ? 2 : 1;
    }

    public void SetSelected(Unit u)
    {
        this._selectedUnit = u;
    }
    public void SetTargeted(Unit u)
    {
        this._targetedUnit = u;
    }
}

