using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static List<List<GameObject>> _board;
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

        List<Vector2> unitsToAffect = GetEffected(a, u, targetPos);
        foreach (Vector2 unitPos in unitsToAffect)
        {
            float falloffMultiplier = GetFalloffModifier(unitPos, targetPos, a._range);
            a.SetEffectFalloff(falloffMultiplier);
            _board[(int)unitPos.x][(int)unitPos.y].GetComponent<EffectController>().AddEffects(a._effects);
        }
    }
    public static List<Vector2> GetEffected(Action a, Unit u, Vector2 targetPos)
    {
        List<Vector2> unitsToAffect = new List<Vector2>();
        for (int x = 0; x < _board.Count; x++)
        {
            for (int y = 0; y < _board[x].Count; y++)
            {
                Vector2 unitPos = new Vector2(x, y);
                if (unitPos == new Vector2(2,1))
                {

                }
                bool inRange = IsInRange(unitPos, targetPos, a._range);
                int? uTeam = _board[x][y]?.GetComponent<Unit>()._team;
                bool unitEffected = IsUnitEffected(_board[x][y]?.GetComponent<Unit>()._team, Game._currentTeam, a._targetFirendly);
                if (inRange && unitEffected) { unitsToAffect.Add(unitPos); }
            }
        }
        unitsToAffect = PruneAType(unitsToAffect, targetPos, a._aType);
        return unitsToAffect;
    }
    private static bool IsInRange(Vector2 unitPos, Vector2 targetPos, float range)
    {
        float dist = Vector2.Distance(unitPos, targetPos);
        return dist <= range;
    }    
    public static bool IsUnitEffected(int? unitTeam, int currentTeam, bool targetFriendly)
    {
        unitTeam = unitTeam == null ? 0 : unitTeam;
        //Debug.Log($"{unitTeam},{currentTeam},{targetFriendly}: {((unitTeam == currentTeam) && targetFriendly) || ((unitTeam != currentTeam) && !targetFriendly)}");
        return ((unitTeam == currentTeam) && targetFriendly) || ((unitTeam != currentTeam) && !targetFriendly);
    }    
    private static List<Vector2> PruneAType(List<Vector2> units, Vector2 targetPos, ActionType aType)
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
    private static float GetFalloffModifier(Vector2 unitPos, Vector2 targetPos, int range)
    {
        float falloff = 0;
        float dist = Vector2.Distance(unitPos, targetPos);
        falloff = (Mathf.Cos(dist * Mathf.PI / range) + 1) / 2;
        return falloff;
    }

}
