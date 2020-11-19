using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddonBase : MonoBehaviour
{
    public int weaponIndex;
    public bool canShoot = false;

    /// <summary>
    /// cambio la cadencia de disparo con una corutina y un booleano
    /// </summary>
    public float coolDown = 3;
    public bool isInCooldown;

    public float alphaCooldown;
    public static event FNotify_2Params<int,float> OnCooldownChange;

    public void OnDisable()
    {
        NewPlayerController.OnFireDown -= NewPlayerController_OnFireDown;
        NewPlayerController.OnFireRelease -= NewPlayerController_OnFireRelease;
        NewPlayerController.OnFireHold -= NewPlayerController_OnFireHold;

        NewPlayerController.OnWeaponIndexChange -= NewPlayerController_OnWeaponIndexChange;
    }
    public void OnEnable()
    {

        NewPlayerController.OnFireDown += NewPlayerController_OnFireDown;
        NewPlayerController.OnFireRelease += NewPlayerController_OnFireRelease;
        NewPlayerController.OnFireHold += NewPlayerController_OnFireHold;

        NewPlayerController.OnWeaponIndexChange += NewPlayerController_OnWeaponIndexChange;

        canShoot = weaponIndex == 0;
    }

    private void NewPlayerController_OnWeaponIndexChange(int NewWeaponIndex)
    {
        canShoot = NewWeaponIndex == weaponIndex;
    }


    protected virtual void NewPlayerController_OnFireHold()
    {
       
    }

    protected virtual void NewPlayerController_OnFireRelease()
    {
        
    }

    protected virtual void NewPlayerController_OnFireDown()
    {
      
    }
    protected virtual void TryToShoot()
    {

       

    }
    public virtual void BeginCooldown()
    {
        isInCooldown = true;
        LeanTween.value(gameObject,OnCoolDownUpdate, 1,0,coolDown).setOnComplete(OnCooldownCompleted) ;
    }

    public virtual void OnCoolDownUpdate(float CooldownPercent)
    {
        alphaCooldown = CooldownPercent;
        OnCooldownChange?.Invoke(weaponIndex, alphaCooldown);
      //  print(alphaCooldown + "  " + alphaCooldown);

    }
    void OnCooldownCompleted()
    {
        isInCooldown = false;
    }


}
