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
    void MoveShip()
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");

        moveDirection = Vector3.RotateTowards(transform.forward, new Vector3(hMovement, 0, vMovement), 1, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * rotationSpeed);

        rb.velocity = transform.forward * moveSpeed;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
    }
}
