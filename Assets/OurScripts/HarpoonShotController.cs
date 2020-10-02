﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonShotController : MonoBehaviour
{
    Transform playerTransform;
    public Transform harpoonFirePoint;
    public bool isShootingHarpoon = false;
    public BulletController harpoonF;
    public float harpoonSpeedF = 3;

    public float cadence = 3;
    private float counter;

    void Awake()
    {
        playerTransform = transform.parent;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            // Harpoon Shoot

            if (isShootingHarpoon)
            {

                counter = cadence;

                BulletController newBullet = Instantiate(harpoonF, harpoonFirePoint.position,playerTransform.rotation) as BulletController;

                newBullet.bulletSpeed = harpoonSpeedF;
            }

            else
            {
                isShootingHarpoon = false;

                counter = 0;
            }
        }
    }
}
