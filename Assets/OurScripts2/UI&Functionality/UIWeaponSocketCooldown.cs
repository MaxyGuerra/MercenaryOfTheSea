using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponSocketCooldown : MonoBehaviour
{
    public Image cooldownFill;
    public Image selectionIcon;
    public TextMeshProUGUI cooldowntext;
    public int weaponIndex;

    private void OnDisable()
    {
        AddonBase.OnCooldownChange -= AddonBase_OnCooldownChange;
        NewPlayerController.OnWeaponIndexChange  -= NewPlayerController_OnWeaponIndexChange;
    }

    private void OnEnable()
    {
        AddonBase.OnCooldownChange += AddonBase_OnCooldownChange;
        NewPlayerController.OnWeaponIndexChange += NewPlayerController_OnWeaponIndexChange;
    }

    private void NewPlayerController_OnWeaponIndexChange(int Param1)
    {
        ActivateSelectionIcon(Param1 == weaponIndex);
    }
    void ActivateSelectionIcon(bool isSelected)
    {
        selectionIcon.gameObject.SetActive(isSelected);
    }
 
    private void AddonBase_OnCooldownChange(int CallerWeaponIndex, float progressAlpha)
    {
        if (weaponIndex != CallerWeaponIndex) return;
        cooldownFill.fillAmount = progressAlpha;
        cooldowntext.SetText(progressAlpha.ToString("00"));


    }

  

}
