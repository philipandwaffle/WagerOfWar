using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private bool _debug;
    [SerializeField] private List<Effect> _effects;
    private Unit _me;

    private void Start()
    {
        _effects = new List<Effect>();
        _me = GetComponent<Unit>();
    }

    public void SpendEffects()
    {
        if (_effects.Count > 0)
        {
            foreach (Effect e in _effects)
            {
                e.Execute(_me);

            }
            PruneEffects();
        }
    }
    private void PruneEffects()
    {
        List<Effect> newEffects = new List<Effect>();
        foreach (Effect e in _effects)
        {
            if (!e._spent) { newEffects.Add(e); }
        }
        this._effects = newEffects; 
    }
    public void AddEffects(List<Effect> effects)
    {
        foreach (Effect e in effects)
        {
            _effects.Add(e);
            if (_debug) { Debug.Log($"Applying {e} to {_me.name}"); }
        }
    }
}
