using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnUnitReceiver : MonoBehaviour
{
    [SerializeField] private UIController _uic;
    public void Start()
    {
        _uic = GetComponent<UIController>();
        GameEvents.events._onOwnUnitClicked += SetCurrentUnit;
    }
    private void SetCurrentUnit(Unit u)
    {
        _uic.SetCurrentUnit(u);
    }
}
