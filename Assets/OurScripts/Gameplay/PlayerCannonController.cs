using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonController : MonoBehaviour
{
    Transform playerTransform;
    public Transform firePoint;
    public bool canShoot = false;
    public BulletController cannonBall;
    public float cannonSpeed = 3;

    public float shootingPower;

    public float cadence = 3;
    private float counter;

    [Header("Rotation Settings")]
    public float rotationSpeed = 3;
    public Camera mainCamara;
   

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
