using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    List<Effect> _effects;
    Unit _me;

    public void Start()
    {
        _effects = new List<Effect>();
        _me = GetComponent<Unit>();
    }

    public void ExecuteEffects()
    {
        foreach (Effect effect in _effects)
        {
            effect.Execute(_me);
        }
    }

}
