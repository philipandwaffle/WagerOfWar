using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SendAttack : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Attack a = gameObject.GetComponent<UIAttackController>()._attack;
            if (a != null)
            {
                GameEvents.events.SetSelectedAttack(a);
            }
        }
    }
}
