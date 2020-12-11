using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
      void  ApplyDamage(float Damage,EWeaponType weaponType=EWeaponType.None);
     

}
 

public interface IUsable
{
     
    void Deactivate( );

    void Activate();

    void ActivateOnce();

}
