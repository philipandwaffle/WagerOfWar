using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private static List<List<GameObject>> _board;
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

    public static void ApplyEffects(Action a, Unit u)
    {
        Vector2 targetPos = new Vector2((int)(u?.name[0] - '0'), (int)(u.name[2] - '0'));
        List<Vector2> unitsToAffect = new List<Vector2>();
        for (int x = 0; x < _board.Count; x++)
        {
            for (int y = 0; y < _board[x].Count; y++)
            {
                float dist = Vector2.Distance(new Vector2(x, y), targetPos);
                if(dist <= a._range && _board[x][y].GetComponent<Unit>()) { unitsToAffect.Add(new Vector2(x, y)); }
            }
        }
        unitsToAffect = PruneEffected(unitsToAffect, targetPos, a._aType);
        foreach (Vector2 unitPos in unitsToAffect)
        {
            _board[(int)unitPos.x][(int)unitPos.y].GetComponent<EffectController>().AddEffects(a._effects);
        }
    }
    private static List<Vector2> PruneEffected(List<Vector2> units, Vector2 targetPos, ActionType aType)
    {
        List<Vector2> prunedUnits = new List<Vector2>();
        foreach (Vector2 unitPos in units)
        {
            switch (aType)
            {
                case ActionType.circle:
                    prunedUnits.Add(unitPos);
                    break;
                case ActionType.cross:
                    if (unitPos.x == targetPos.x || unitPos.y == targetPos.y) { prunedUnits.Add(unitPos); }
                    break;
                case ActionType.diagonal:
                    Vector2 adjustedPoint = unitPos - targetPos;
                    if (Mathf.Abs(adjustedPoint.x) == Mathf.Abs(adjustedPoint.y)) { prunedUnits.Add(unitPos); }
                    break;
                case ActionType.horizontal:
                    if (targetPos.x == unitPos.x) { prunedUnits.Add(unitPos); }
                    break;
                case ActionType.vertical:
                    if (targetPos.y == unitPos.y) { prunedUnits.Add(unitPos); }
                    break;
            }
        }
        return prunedUnits;
    }
    private static List<Vector2> PruneOwnedUnits(List<Vector2> units)
    {
        List<Vector2> prunedUnits = new List<Vector2>();
        foreach (Vector2 pos in units)
        {
            throw new System.NotImplementedException();
            //float midPoint = _board.Count / 2;
            //Game._currentTeam
            //if (pos.x )
        }
        return prunedUnits;
    }
    private static float GetFalloffModifier(float dist, int range)
    {
        float falloff = 0;
        falloff = (Mathf.Cos((dist / range) * Mathf.PI) / 2) + 0.5f;
        return falloff;
    }

}
