using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 1;
    public float rotationSpeed = 1;
    private Vector3 moveDirection = Vector3.zero;

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
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");

         moveDirection = Vector3.RotateTowards(transform.forward, new Vector3(hMovement,0 , 0), moveSpeed, 0);
        //moveDirection += new Vector3(hMovement, 0, 0) * moveSpeed;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * rotationSpeed);
        //rb.velocity = transform.forward * moveSpeed * vMovement;
        rb.velocity = transform.forward * moveSpeed * Mathf.Clamp(vMovement, 0, 1);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
    }
}
