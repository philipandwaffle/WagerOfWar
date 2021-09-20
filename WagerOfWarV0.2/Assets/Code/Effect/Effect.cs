using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect : MonoBehaviour
{
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    protected Unit _me;

    public virtual void Start()
    {
        _me = GetComponent<Unit>();
    }

    public abstract void Execute();
    public void RemoveEffect() 
    {
        Destroy(this);
    }
}
