using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public Slider _healthbar;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth(float health)
    {
        _healthbar.maxValue = health;
        _healthbar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        _healthbar.value = health;

        fill.color = gradient.Evaluate(_healthbar.normalizedValue);
    }

}
