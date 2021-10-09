using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static List<List<GameObject>> _board;
    [SerializeField] public float _spacing;

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
        g.transform.SetParent(gameObject.transform);    //after hitting F10 units in col 3 are set when col 2 are only supposed to 
        g.transform.position = new Vector3(x * _spacing, y * _spacing, 0);
        g.name = $"{x},{y}:\t{g.GetComponent<Unit>()._name}";
        g.GetComponent<SpriteController>().SetFlipX(x >= _board.Count / 2);
        g.GetComponent<Unit>()._team = x >= _board.Count / 2 ? 2 : 1;
    }

    public void ApplyEffects(Action a, Unit u)
    {
        Vector2 targetPos = new Vector2((int)(u?.name[0] - '0'), (int)(u.name[2] - '0'));

        List<Vector2> unitsToAffect = GetEffected(a, targetPos);
        foreach (Vector2 unitPos in unitsToAffect)
        {
            float falloffMultiplier = GetFalloffModifier(unitPos, targetPos, a._range);
            a.SetEffectFalloff(falloffMultiplier);
            _board[(int)unitPos.x][(int)unitPos.y]?.GetComponent<EffectController>().AddEffects(a._effects);
        }
    }
    private List<Vector2> GetEffected(Action a, Vector2 targetPos)
    {
        List<Vector2> unitsToAffect = new List<Vector2>();
        for (int x = 0; x < _board.Count; x++)
        {
            for (int y = 0; y < _board[x].Count; y++)
            {
                GameObject go = _board[x][y];
                bool unitExists = _board[x][y]?.Equals(null) == null ? false : !_board[x][y].Equals(null);
                if (unitExists)
                {
                    Vector2 unitPos = new Vector2(x, y);
                    bool inRange = IsInRange(unitPos, targetPos, a._range);
                    int uTeam = _board[x][y].GetComponent<Unit>()._team;
                    bool unitEffected = IsUnitEffected(_board[x][y].GetComponent<Unit>()._team, Game._currentTeam, a._targetFirendly);
                    if (inRange && unitEffected) { unitsToAffect.Add(unitPos); }
                }
            }
        }
        unitsToAffect = PruneAType(unitsToAffect, targetPos, a._aType);
        return unitsToAffect;
    }
    private bool IsInRange(Vector2 unitPos, Vector2 targetPos, float range)
    {
        float dist = Vector2.Distance(unitPos, targetPos);
        return dist <= range;
    }    
    public bool IsUnitEffected(int uTeam, int currentTeam, bool targetFriendly)
    {
        //Debug.Log($"{unitTeam},{currentTeam},{targetFriendly}: {((unitTeam == currentTeam) && targetFriendly) || ((unitTeam != currentTeam) && !targetFriendly)}");
        return ((uTeam == currentTeam) && targetFriendly) || ((uTeam != currentTeam) && !targetFriendly);
    }    
    private List<Vector2> PruneAType(List<Vector2> u, Vector2 tPos, ActionType aType)
    {
        List<Vector2> prunedUnits = new List<Vector2>();
        foreach (Vector2 uPos in u)
        {
            switch (aType)
            {
                case ActionType.circle:
                { 
                prunedUnits.Add(uPos);
                break;
                }
                case ActionType.cross:
                {
                    if (uPos.x == tPos.x || uPos.y == tPos.y) { prunedUnits.Add(uPos); }
                    break;
                }
                case ActionType.diagonal:
                {
                    Vector2 adjustedPoint = uPos - tPos;
                    if (Mathf.Abs(adjustedPoint.x) == Mathf.Abs(adjustedPoint.y)) { prunedUnits.Add(uPos); }
                    break;
                }
                case ActionType.horizontal:
                {
                    if (tPos.y == uPos.y) { prunedUnits.Add(uPos); }
                    break;
                }
                case ActionType.vertical:
                {
                    if (tPos.x == uPos.x) { prunedUnits.Add(uPos); }
                    break;
                }
            }
        }
        return prunedUnits;
    }
    private float GetFalloffModifier(Vector2 unitPos, Vector2 targetPos, int range)
    {
        float falloff = 0;
        float dist = Vector2.Distance(unitPos, targetPos);
        falloff = (Mathf.Cos(dist * Mathf.PI / range) + 1) / 2;
        return falloff;
    }

    public void SpendEffects()
    {
        for (int x = 0; x < _board.Count; x++)
        {
            for (int y = 0; y < _board[x].Count; y++)
            {
                if (_board[x][y] == null || _board[x][y].Equals(null)) { break; }
                _board[x][y]?.GetComponent<EffectController>().SpendEffects();
            }
        }
    }
}
