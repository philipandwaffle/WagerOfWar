using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionController : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private string _defaultIcon;
    [SerializeField] private Text _details;
    public Action _action { private set; get; }

    public void UpdateAction(Action action)
    {
        this._action = action;
        gameObject.SetActive(true);
        if (action == null)
        {
            gameObject.SetActive(false);
            _icon.sprite = Resources.Load<Sprite>(_defaultIcon);
            _details.text = "NO ACTION";
            return;
        }
        _icon.sprite = Resources.Load<Sprite>(action._sprite);
        _details.text = action.GenDetails();
        
    }

}
