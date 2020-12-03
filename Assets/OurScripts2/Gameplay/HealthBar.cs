using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _healthbar;
 

    public void SetMaxHealth(int health)
    {
        _healthbar.maxValue = health;
        _healthbar.value = health;
    }

    public void SetHealth(int health)
    {
        _healthbar.value = health;
    }

    
}
