using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private List<List<GameObject>> _board;
    [SerializeField] public float _spacing;

    private Board(List<List<GameObject>> board)
    {
        _board = board;
    }
    public void PopulateBoard(List<List<GameObject>> board)
    {
        _board = board;
    }

    public void PlaceUnits()
    {
        for (int x = 0; x < _board.Count; x++)
        {
            for (int y = 0; y < _board[x].Count; y++)
            {
                if (_board[x][y] != null)
                {
                    _board[x][y] = Instantiate(_board[x][y]);
                    SetUpUnit(_board[x][y], x, y);
                }
            }
        }
    }

    private void SetUpUnit(GameObject g, int x, int y)
    {
        g.transform.SetParent(gameObject.transform);
        g.transform.position = new Vector3(x * _spacing, y * _spacing, 0);
        g.name = $"{x},{y}:\t{g.GetComponent<Unit>()._name}";
        g.GetComponent<SpriteController>().SetFlipX(x >= _board.Count / 2);
        g.GetComponent<Unit>()._team = x >= _board.Count / 2 ? 2 : 1;
    }

    public void ExecuteEffects()
    {
        foreach (List<GameObject> col in _board)
        {
            foreach (GameObject unit in col)
            {
                unit.GetComponent<Effect>()?.Execute();
            }
        }
    }
}
