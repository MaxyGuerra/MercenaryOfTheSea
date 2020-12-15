using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddonMineCannon : AddonBase
{
    public GameObject mineGameObject;
    private float counter;

    private Transform playerTransform;
    [SerializeField] protected Vector3 spawnPositionOffset;
    private void Awake()
    {
        playerTransform = transform.parent;
    }
    protected override void NewPlayerController_OnFireDown()
    {
        TryToShoot();

    }


    protected override void TryToShoot()
    {
        if (!canShoot) return;

        if (isInCooldown) return;
        BeginCooldown();


        Instantiate(mineGameObject,  transform.position+ spawnPositionOffset, Quaternion.identity);

    }
}

