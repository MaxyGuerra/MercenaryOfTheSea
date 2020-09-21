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
    private float counter;
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

            if (isShooting)
            {

                counter = cadence;

                BulletController newBullet = Instantiate(bulletC, firePoint.position, firePoint.rotation) as BulletController;

                newBullet.bulletSpeed = bulletSpeedC;
            }

            else
            {
                isShooting = false;

                counter = 0;
            }

        }
      
    }
}
