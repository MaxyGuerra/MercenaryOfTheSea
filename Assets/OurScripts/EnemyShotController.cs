using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    [Header("Rotation and Following Settings")]
    public Transform playerPosition;
    public float rotationSpeed = 1f;


    [Header("Shooting Settings")]

    public bool canShoot = false;
    public Transform firePoint;
    public float shootingDistance = 8;
    public BulletController enemyBullet;
    public float enemyBulletSpeed = 1;

    public float cadence = 3;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
    
        Vector3 direction = playerPosition.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootingDistance) canShoot = true; 
        else canShoot = false;

        if (canShoot)
        {

            counter -= Time.deltaTime;

            if (counter <= 0)
            {

                counter = cadence;

                BulletController newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation) as BulletController;

                newBullet.bulletSpeed = enemyBulletSpeed;
            }
        }
        
    }
}
