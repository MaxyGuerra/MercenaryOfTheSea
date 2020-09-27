using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCController : MonoBehaviour
{
    public float cadence = 3;
    private float counter = 3;

    public Transform cannonCFirePoint;
    public bool isShootingCannonC = false;
    public BulletController cannonC;
    public float CannonCBulletSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

            // Left Cannon Shoot

              if (isShootingCannonC)
              {
                  counter = cadence;
                  //BulletController newBullet = Instantiate(cannonC, transform.position += Vector3.right * Time.deltaTime * -CannonCBulletSpeed) as BulletController;

                 // newBullet.bulletSpeed = CannonCBulletSpeed;
        }

              else
              {
                  isShootingCannonC = false;

                  counter = 0;
              }
   

    }
}

