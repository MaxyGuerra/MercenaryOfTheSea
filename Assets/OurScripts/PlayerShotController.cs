using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    public bool isShooting = false;
    public Transform firePoint;

    public BulletController bulletC;
    public float bulletSpeedC = 3;

    public float cadence = 3;
    private float shootCounterC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootCounterC -= Time.deltaTime;

        if (shootCounterC <= 0)
        {

            if (isShooting)
            {

                shootCounterC = cadence;

                BulletController newBullet = Instantiate(bulletC, firePoint.position, firePoint.rotation) as BulletController;

                newBullet.bulletSpeed = bulletSpeedC;
            }

            else
            {
                isShooting = false;

                shootCounterC = 0;
            }

        }
      
    }
}
