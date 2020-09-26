using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    public float cadence = 3;
    private float counter;

    [Header("Harpoon")]

    public Transform harpoonFirePoint;
    public bool isShootingHarpoon = false;
    public BulletController harpoonF;
    public float harpoonSpeedF = 3;


    [Header("CannonLeft")]
    public Transform cannonCFirePoint;
    public bool isShootingCannonC = false;
    public BulletController cannonC;
    public float cannonCSpeed;


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

                BulletController newBullet = Instantiate(harpoonF, harpoonFirePoint.position, harpoonFirePoint.rotation) as BulletController;

                newBullet.bulletSpeed = harpoonSpeedF;
            }

            else
            {
                isShootingHarpoon = false;

                counter = 0;
            }

            // Left Cannon Shoot

            if (isShootingCannonC)
            {
                counter = cadence;

                BulletController newBulletC = Instantiate(cannonC, cannonCFirePoint.position, cannonCFirePoint.rotation) as BulletController;
            }

            else
            {
                isShootingCannonC = false;

                counter = 0;
            }


            //Right Cannon Shoot
        }
      
    }
}
