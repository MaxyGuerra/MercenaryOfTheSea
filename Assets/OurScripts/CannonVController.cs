using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonVController : MonoBehaviour
{

    public float cadence = 3;
    private float counter;
    public PlayerController playerReference;

    public Transform cannonVFirePoint;
    public bool isShootingCannonV= false;
    public BulletController cannonVBullet;
    public float CannonVBulletSpeed;
    

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
            if (isShootingCannonV)
            {
                counter = cadence;
                BulletController newBullet = Instantiate(cannonVBullet, transform.right, transform.rotation) as BulletController;

                newBullet.bulletSpeed = CannonVBulletSpeed;
            }

            else
            {
                isShootingCannonV = false;

                counter = 0;
            }


        }
    }
}
