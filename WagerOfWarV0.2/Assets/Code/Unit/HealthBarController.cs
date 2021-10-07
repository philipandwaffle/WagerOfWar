using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private GameObject _armourBar;
    [SerializeField] private GameObject _barContainer;
    [SerializeField] private Text _healthTxt;
    [SerializeField] private Text _armourTxt;

    private float _total;

    public void InitBar(float maxHealth, float maxArmour)
    {
        _total = maxHealth + maxArmour;
        UpdateBar(maxHealth, maxArmour);
    }

    public void UpdateBar(float health, float armour)
    {
        this._healthTxt.text = Mathf.Ceil(health).ToString();
        this._armourTxt.text = Mathf.Ceil(armour).ToString();
        float healthScale = health / _total;
        float armourScale = armour / _total;

        _healthBar.transform.localScale = new Vector3(healthScale, 0.5f, 1);
        _armourBar.transform.localScale = new Vector3(armourScale, 0.5f, 1);
        _armourBar.transform.localPosition = new Vector3(0.5f * healthScale * -_barContainer.transform.localPosition.x, 0, 0);
    }
}
