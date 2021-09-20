using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttackController : MonoBehaviour
{
    [SerializeField] public Image _attackImage;
    [SerializeField] public Text _attackDetails;
    public Attack _attack;

    public void UpdateAttack(Attack a)
    {
        this._attack = a;
        _attackImage.sprite = Resources.Load<Sprite>(a._sprite);
        _attackDetails.text = GenDetails();
    }
    private string GenDetails()
    {
        string s = "";
        s += $"Name:\t\t\t{_attack._name}\n";
        s += $"Damage:\t\t{_attack._damage}\n";
        s += $"Attack Type:\t{_attack._type}\n";
        s += $"{_attack._description}";
        return s;
    }
}
