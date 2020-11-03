using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour
{
    Transform playerTransform;
    public Transform firePoint;
    public bool canShoot = false;
    public Rigidbody cannonBallBullet;
    


    public float cadence = 3;
    private float counter;

    
    //[Header("")]
    
    private Camera mainCamara;
    public GameObject cursor; 
    public LayerMask layer;
    
   

    // Start is called before the first frame update
    void Start()
    {
        mainCamara = Camera.main;
    }

    void ShootCannonBall()
    {
        

    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float timeInAir)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //Float to represent distance  

        float heightY = distance.y;
        float heightXZ = distanceXZ.magnitude;

        float Vxz = heightXZ / timeInAir;
        float Vy = heightXZ / timeInAir + 0.5f * Mathf.Abs(Physics.gravity.y) * timeInAir;


        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy; 

        return result;

    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = mainCamara.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLeght;

        if(groundPlane.Raycast(cameraRay,out rayLeght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLeght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
        }

        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            // CannonShoot

            if (canShoot)
            {
                counter = cadence;

                {
                    ShootCannonBall();
                }

            }

            else
            {
                canShoot= false;

                counter = 0;
            }
        }
    }
}
