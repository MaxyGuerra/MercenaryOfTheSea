using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCController : MonoBehaviour
{
    public float cadence = 3;
    private float counter;

    public Transform cannonCFirePoint;
    public bool isShootingCannonC = false;
    public BulletController cannonCBullet;
    public float CannonCBulletSpeed;


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
            if (isShootingCannonC)
            {
                counter = cadence;
                BulletController newBullet = Instantiate(cannonCBullet, transform.position + Vector3.right * Time.deltaTime * -CannonCBulletSpeed, Quaternion.Euler(0, -90,0)) as BulletController;

                newBullet.bulletSpeed = CannonCBulletSpeed;
            }

            else
            {
                isShootingCannonC = false;

                counter = 0;
            }


        }
    }
}

