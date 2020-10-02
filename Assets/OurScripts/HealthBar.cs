using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _healthbar;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMaxHealth(int health)
    {
        _healthbar.maxValue = health;
        _healthbar.value = health;
    }

    public void SetHealth(int health)
    {
        _healthbar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
