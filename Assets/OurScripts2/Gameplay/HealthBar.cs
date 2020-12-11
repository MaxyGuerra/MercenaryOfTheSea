using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _healthbar;
 

    public void SetMaxHealth(float health)
    {
        _healthbar.maxValue = health;
        _healthbar.value = health;
    }

    public void SetHealth(float health)
    {
        _healthbar.value = health;
    }

    
}
