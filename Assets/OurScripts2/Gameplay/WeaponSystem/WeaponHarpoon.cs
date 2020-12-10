using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType { CannonBall,Harpoon, MineCannon}
public class WeaponHarpoon : AddonBase
{
    [Header("Harpoon settings")]
    public Rigidbody HarpoonBullet;
    private Transform playerTransform;

    public float shootPower=10;

    private void Awake()
    {
        playerTransform = transform.parent;
    }
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
            Rigidbody bullet = Instantiate(HarpoonBullet, transform.position, playerTransform.rotation);
            // bullet.velocity = CalculateVelocity(hit.point, transform.position, 1f);
            bullet.velocity = transform.forward * shootPower;
    }

   
}
