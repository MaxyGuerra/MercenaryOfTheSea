using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    [Header("Rotation and Following Settings")]
    public Transform playerPosition;
    public float rotationSpeed = 1f;

    [Header ("Shooting Settings")]

    public bool isShooting = true;
    public Transform firePoint;

    public BulletController enemyBullet;
    public float enemyBulletSpeed = 1;

    public float cadence = 3;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ShootingPlayer()
    {
        Vector3 direction = playerPosition.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        counter -= Time.deltaTime;

        if (counter <= 0)
        {

            if (isShooting)
            {

                counter = cadence;

                BulletController newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation) as BulletController;

                newBullet.bulletSpeed = enemyBulletSpeed;
            }

            else
            {
                isShooting = false;

                counter = 0;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        ShootingPlayer();
    }
}
