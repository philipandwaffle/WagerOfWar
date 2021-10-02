using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Create Scriptable/Effect")]
[System.Serializable]
public abstract class Effect : ScriptableObject
{
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    public bool _Used { private set; get; }

    public abstract void Execute(Unit u);
}
