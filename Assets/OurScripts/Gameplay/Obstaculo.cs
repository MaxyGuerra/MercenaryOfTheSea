﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour,IDamageable
{
    public void ApplyDamage(int Dmg, EWeaponType weaponType)
    {
        Destroy(gameObject);
    }
 
}
