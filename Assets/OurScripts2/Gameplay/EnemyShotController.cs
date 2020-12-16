using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EShootStatus {OK, COOLDOWN,OUT_OF_RANGE,}
public class EnemyShotController : MonoBehaviour
{
    [Header("Rotation and Following Settings")]
    public Transform playerPosition;
    public float rotationSpeed = 1f;


    [Header("Shooting Settings")]

    public bool bIsInCooldown = false;
    public Transform firePoint;
    public float shootingDistance = 8;
    public float offset = 1;
    public BulletController enemyBullet;
    public float enemyBulletSpeed = 1;

    public float cadence = 3;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
    }


    public EShootStatus TryToShoot(Transform Target)
    {
        if(bIsInCooldown)return EShootStatus.COOLDOWN;

        if(!GetIsInRange(Target.position))
        {
            return EShootStatus.OUT_OF_RANGE;
        }
        bIsInCooldown=true;
        BulletController newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation) as BulletController;

        
        newBullet.ShootToDirection(transform.forward.normalized,enemyBulletSpeed);

        StartCoroutine(WaitForCooldown());
        return EShootStatus.OK;

    }
    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(cadence);
        bIsInCooldown=false;
    }
 
    bool GetIsInRange(Vector3 targetPosition)
    {
        return     Vector3.Distance(transform.position, targetPosition) < shootingDistance;

    }
    void Update()
    {

        Vector3 direction = playerPosition.position - transform.position + new Vector3(0, offset, 0);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        
        
    }
}
