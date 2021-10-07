using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tester : MonoBehaviour, IPointerClickHandler
{    
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LogDebug(string s)
    {
        Debug.Log($"TESTER: {s}");
    }
}
