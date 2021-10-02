using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/Effect")]
[System.Serializable]
public abstract class Effect : ScriptableObject
{
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    protected Unit _me;

    public abstract void Execute(Unit u);
}
