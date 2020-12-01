using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponDefinition
{
    public EWeaponType weaponType;
    public int baseDamage;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponsDatabase", order = 1)]

public class WeaponsDatabase : SingletonScriptableObject<WeaponsDatabase>
{ 
    public WeaponDefinition[] weapons;

    public WeaponDefinition GetWeaponDefinition(EWeaponType eWeaponType)
    {
        for (int i = 0; i <  weapons.Length; i++)
        {
            if ( weapons[i].weaponType == eWeaponType)
            {
                return  weapons[i];
            }
        }

        return null;
    }


}
