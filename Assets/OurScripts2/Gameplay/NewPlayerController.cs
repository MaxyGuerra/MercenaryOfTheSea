using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NewEPlayerActions { NONE, PlayerMove, ShootingHarpoon, ShootingCannon }
//todo: deprecated?
public enum EPlayerActions { NONE, PlayerMove, ShootingHarpoon, ShootingCannon }



public class NewPlayerController : MonoBehaviour,IDamageable
{
   
    public float playerHealth = 10; 
    public PlayerHealthBar playerHealthBar;
    public CanvasGroup loseScreen;
    //AudioClip playerDeath;
    public float moveSpeed = 1;
    public float rotationSpeed = 1;
    private Vector3 moveDirection = Vector3.zero;

    Rigidbody rb;
    public   bool canMove = true;
 

    public static NewPlayerController instance;

    private bool isRespawning;
    private Vector3 respawnPoint;

    [Header("Weapon Selection")]
    public int currentWeaponIndex;    

    [Header("NewHook")]
    public Joint joint;
    public LineRenderer hookLine;

    public GameObject compass;


    public static event FNotify OnFireDown, OnFireHold, OnFireRelease;
    public static event FNotify_1Params<int> OnWeaponIndexChange;

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
        playerHealthBar.SetMaxHealth(playerHealth);
    }
    private void OnEnable()
    {
        GameManager.OnBossCollected += GameManager_OnBossCollected;
        BossAIScript.OnBossDead += BossAIScript_OnBossDead;
        hookLine.positionCount = 0;
    }


    private void OnDisable()
    {
        GameManager.OnBossCollected -= GameManager_OnBossCollected;

        BossAIScript.OnBossDead -= BossAIScript_OnBossDead;

    }
    private void BossAIScript_OnBossDead(Transform BossTransform)
    {

        joint.connectedBody = BossTransform.GetComponent<BossAIScript>().SetHooked(true);

    }


    private void GameManager_OnBossCollected(BossAIScript Param1)
    {
        joint.connectedBody = null;

        hookLine.positionCount =0;
    }


    void DrawHookLine()
    {
        if (joint.connectedBody == null) return;
        hookLine.positionCount = 2;
        hookLine.SetPosition(0, transform.position);
        hookLine.SetPosition(1, joint.connectedBody.position);

        compass.gameObject.SetActive(true);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + moveDirection * 10);
        Gizmos.color = Color.red; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tentaculos"))
        {
            playerHealth--;

            playerHealthBar.SetHealth(playerHealth);

            if (playerHealth <= 0)
            {
                playerHealth = 0;

                PlayerIsDead();
            }

        }
    }

 

    void PlayerIsDead()
    {
        //_audioSource.PlayOneShot(playerDeath);

        loseScreen.gameObject.SetActive(true);

        Time.timeScale = 0;

        PlayerRespawn();
    }

    void PlayerRespawn()
    {
        transform.position = respawnPoint;
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    void MoveShip()
    {
        float h = (canMove ? Input.GetAxis("Horizontal") : 0);
        float v = (canMove ? Input.GetAxis("Vertical") : 0);

        moveDirection = Vector3.RotateTowards(transform.forward, new Vector3(h, 0, v), 1, 0);

        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + h, 0));

        //  transform.rotation=Quaternion.LookRotation(moveDirection);

        rb.velocity = transform.forward * moveSpeed * Mathf.Clamp(v, 0, 1);
        if (rb.velocity.magnitude > 0.9f) OnPlayerActionActivate?.Invoke(EPlayerActions.PlayerMove);


    }
 
   void UpdateFireInput()
    {
         /*
            cannon.TryToShootCannon();
            OnPlayerActionActivate?.Invoke(EPlayerActions.ShootingCannon);*/
        if (Input.GetButtonUp("Fire1") )
        {
            OnFireRelease ?.Invoke();
            return;

        }
        if (Input.GetButtonDown("Fire1"))
        {
            OnFireDown?.Invoke();
            return;

        }
        if (Input.GetButton("Fire1"))
        {
            OnFireHold?.Invoke();

        }
    

       
    }


    void UpdateWeaponIndex()
    {
        //   Para agregar más armas.

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeaponIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeaponIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeaponIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeWeaponIndex(3);



    }
    void ChangeWeaponIndex(int nextWeapon)
    {
            currentWeaponIndex = nextWeapon;
         //   print(currentWeaponIndex + "  " + nextWeapon);

            OnWeaponIndexChange?.Invoke(currentWeaponIndex);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
        DrawHookLine();

        UpdateWeaponIndex();
        UpdateFireInput();



        if(Input.GetKeyDown(KeyCode.X))
        {
            playerHealth = -2;
        }
    }
 

    public void ApplyDamage(float Damage, EWeaponType weaponType)
    {
        playerHealth -= Damage;
        playerHealthBar.SetHealth(playerHealth);

        if (playerHealth <= 0)
        {
            playerHealth = 0;

            PlayerIsDead();
        }
    }

    public void ForceDestroy(Vector3 _hitPosition)
    {
      
    }
}
