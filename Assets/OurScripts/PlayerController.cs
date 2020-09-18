using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 1;
    public float rotationSpeed = 1;
    private Vector3 moveDirection = Vector3.zero;

    public PlayerShotController cannonC;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + moveDirection * 10);

    }
    void MoveShip()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirection = Vector3.RotateTowards(transform.forward, new Vector3(h, 0, v), 1, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * rotationSpeed);

        //  transform.rotation=Quaternion.LookRotation(moveDirection);
        rb.velocity = transform.forward * moveSpeed * Mathf.Clamp(v, 0, 1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cannonC.isShooting = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
          cannonC.isShooting = false;
        }

    }
}


