﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddonMineCannon : AddonBase
{
    public Rigidbody mineGameObject;
    [SerializeField] private float cadence = 3;
    private float counter;

    private Transform playerTransform;

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


        Instantiate(mineGameObject, playerTransform.transform.position, Quaternion.identity);

    }
}

