using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] GameObject _healthBar;
    [SerializeField] GameObject _armourBar;
    [SerializeField] GameObject _barContainer;
    [SerializeField] UnityEngine.UI.Text _healthTxt;
    [SerializeField] UnityEngine.UI.Text _armourTxt;

    float _maxHealth;
    float _maxArmour;
    float _total;

    public void InitBar(float maxHealth, float maxArmour)
    {
        this._maxHealth = maxHealth;
        this._maxArmour = maxArmour;
        _total = maxHealth + maxArmour;
        UpdateBar(maxHealth, maxArmour);
    }    

    public void UpdateBar(float health, float armour)
    {
        this._healthTxt.text = health.ToString();
        this._armourTxt.text = armour.ToString();
        float healthScale = health / _total;
        float armourScale = armour / _total;

        _healthBar.transform.localScale = new Vector3(healthScale, 0.5f, 1);
        _armourBar.transform.localScale = new Vector3(armourScale, 0.5f, 1);
        _armourBar.transform.localPosition = new Vector3(0.5f * healthScale * -_barContainer.transform.localPosition.x, 0, 0);
    }
}
