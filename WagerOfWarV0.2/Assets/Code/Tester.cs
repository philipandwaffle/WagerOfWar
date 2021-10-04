using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tester : MonoBehaviour, IPointerClickHandler
{    
    public void OnPointerClick(PointerEventData eventData)
    {
        BoardGetEffected();
    }

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 1; i < 3; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    //Debug.Log($"{i} | {j} | {(k == 1).ToString()[0]} | {(Board.IsUnitEffected(i, j, (k == 1))).ToString()[0]}");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BoardGetEffected()
    {
        Vector2 targetPos = new Vector2(3, 0);
        Unit target = Board._board[(int)targetPos.x][(int)targetPos.y].GetComponent<Unit>();
        Action action = target._actions[0];
        List<Vector2> effected = Board.GetEffected(action, target, targetPos);
    }

    private void LogDebug(string s)
    {
        Debug.Log($"TESTER: {s}");
    }
}
