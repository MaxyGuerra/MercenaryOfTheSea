using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour
{
    Transform playerTransform;
    public Transform firePoint;
    public bool canShoot = false;
    public GameObject cannonBallBullet;
    public float shootDistance = 100f;

    //public float m



    public float cadence = 3;
    private float counter;


    [Header("Cursor Settings")]

    private Camera mainCamara;
    public GameObject cursor;
    public LayerMask layer;
    RaycastHit hit;




    // Start is called before the first frame update
    void Start()
    {
        mainCamara = Camera.main;
    }

    void FiringPoint()
    {
        Ray camRay = mainCamara.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hit, shootDistance, layer))
        {
            cursor.transform.position = hit.point + Vector3.up * 1f;

            Vector3 Vo = CalculateVelocity(hit.point, transform.position, 1f);

        }

    }

    void ShootCannon()
    {
       // Rigidbody bullet = Instantiate(cannonBallBullet, firePoint.position, Quaternion.identity);
        //bullet.velocity = CalculateVelocity(hit.point, transform.position, 1f);

        GameObject bullet = Instantiate(cannonBallBullet, firePoint.position, Quaternion.identity);
        bullet.GetComponent < BulletController> ().SetVelocity(firePoint.position, cursor.transform.position);
    }


    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float timeInAir)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //Float to represent distance  

        float heightY = distance.y;
        float heightXZ = distanceXZ.magnitude;

        // Velocity X

        float Vxz = heightXZ / timeInAir;
        float Vy = heightXZ / timeInAir + 0.5f * Mathf.Abs(Physics.gravity.y) * timeInAir;

        //Velocity Y
        Vector3 result = distanceXZ.normalized * Vxz;
        result.y = Vy;

        return result;

    }

    // Update is called once per frame
    void Update()
    {
        /*Ray cameraRay = mainCamara.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLeght;

         if(groundPlane.Raycast(cameraRay,out rayLeght))
         {
            Vector3 pointToLook = cameraRay.GetPoint(rayLeght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
         }*/


        counter -= Time.deltaTime;

        FiringPoint();

        if (counter <= 0)
        {
            // CannonShoot

            if (canShoot == true)
            {
                counter = cadence;
                ShootCannon();

            }

            else
            {
                canShoot = false;

                counter = 0;
            }
        }
    }
}
