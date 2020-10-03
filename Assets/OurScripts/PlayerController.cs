using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerActions { NONE,PlayerMove,ShootingHarpoon,ShootingCannon}
public class PlayerController : MonoBehaviour
{

    public int playerHealth = 10;

    public float moveSpeed = 1;
    public float rotationSpeed = 1;
    private Vector3 moveDirection = Vector3.zero;
    Rigidbody rb;

    public static PlayerController instance;

    public HarpoonShotController harpoon;
    public CannonCController rightCannon;
    public CannonVController leftCannon;

    public Joint joint;
    public LineRenderer hookLine;


    public delegate void FNotifyAction(EPlayerActions currentAction);
    public static event FNotifyAction OnPlayerActionActivate;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        BossAIScript.OnBossDead += BossAIScript_OnBossDead;
        hookLine.positionCount =0;
    }

   

    private void OnDisable()
    {
        BossAIScript.OnBossDead -= BossAIScript_OnBossDead;

    }
    private void BossAIScript_OnBossDead(Transform BossTransform)
    {
        joint.connectedBody = BossTransform.GetComponentInChildren<Rigidbody>();

    }
    void DrawHookLine()
    {
        if (joint.connectedBody == null) return;
        hookLine.positionCount = 2;
        hookLine.SetPosition(0, transform.position);
        hookLine.SetPosition(1, joint.connectedBody.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + moveDirection * 10);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tentaculo"))
        {
            playerHealth--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHealth -= BulletController.damage;

            Destroy(other.gameObject);

            if(playerHealth <= 0)
            {
                playerHealth = 0;
            }
        }
    }

    void MoveShip()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirection = Vector3.RotateTowards(transform.forward, new Vector3(h, 0, v), 1, 0);

        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + Input.GetAxis("Horizontal"), 0));

        //  transform.rotation=Quaternion.LookRotation(moveDirection);
        rb.velocity = transform.forward * moveSpeed * Mathf.Clamp(v, 0, 1);
        if(rb.velocity.magnitude >0.9f) OnPlayerActionActivate?.Invoke(EPlayerActions.PlayerMove);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
        DrawHookLine();
    }

    void Update()
    {
        // Harpoon Shot;

        if (Input.GetKeyDown(KeyCode.F))
        {
           harpoon.isShootingHarpoon = true;
            OnPlayerActionActivate?.Invoke(EPlayerActions.ShootingHarpoon);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
          harpoon.isShootingHarpoon = false;
        }

        // Left Cannon Shot 

       if (Input.GetKeyDown(KeyCode.C))
        {
            rightCannon.isShootingCannonC = true;
            OnPlayerActionActivate?.Invoke(EPlayerActions.ShootingCannon);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            rightCannon.isShootingCannonC = false;
        }

        //Right Cannon Shot

        if (Input.GetKeyDown(KeyCode.V))
        {
            leftCannon.isShootingCannonV = true;
            OnPlayerActionActivate?.Invoke(EPlayerActions.ShootingCannon);
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            leftCannon.isShootingCannonV = false;
        }

    }
}


