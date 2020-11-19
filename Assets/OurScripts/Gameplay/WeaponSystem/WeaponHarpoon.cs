using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHarpoon : AddonBase
{
    [Header("Harpoon settings")]
    public Rigidbody HarpoonBullet;

    public float shootPower=10;

    protected override void NewPlayerController_OnFireDown()
    {
        TryToShoot();

    }

    protected override  void TryToShoot()
    {
        if (!canShoot) return;

        if (isInCooldown) return;
            BeginCooldown();

            // StartCoroutine(CannonCooldown());
            Rigidbody bullet = Instantiate(HarpoonBullet, transform.position, Quaternion.identity);
            // bullet.velocity = CalculateVelocity(hit.point, transform.position, 1f);
            bullet.velocity = transform.forward * shootPower;
       
    }
}
