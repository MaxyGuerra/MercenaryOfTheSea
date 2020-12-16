using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour,IDamageable
{
    AttributeBase attributeBase;
    void Awake()
    {
        attributeBase=GetComponent<AttributeBase>();
    }

    void OnEnable()
    {
        attributeBase.OnAttributeDepletedEvent=OnHpisZero;
    }

    void OnHpisZero()
    {
        Destroy(gameObject);
    }
    public void ApplyDamage(float Dmg, EWeaponType weaponType)
    {
        attributeBase.SubtractToValue(Dmg);
    }
 
}
