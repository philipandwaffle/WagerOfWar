using UnityEngine;

public class OwnUnitReceiver : MonoBehaviour
{
    [SerializeField] private UIController _uic;
    public void Start()
    {
        _uic = GetComponent<UIController>();
        GameEvents.events._onOwnUnitClick += SetCurrentUnit;
    }
    private void SetCurrentUnit(Unit u)
    {
        _uic.SetCurrentUnit(u);
    }
}
