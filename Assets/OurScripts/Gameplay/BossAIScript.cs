using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum BossState { IDLE,FOLLOW,DEAD}
public class BossAIScript : MonoBehaviour, IDamageable
{

    NavMeshAgent navAgent;
    public float remainingDistance; 
    public Transform playerTarget;
    public bool isFollowingPlayer = false;
    public delegate void FBossDeadNotify(Transform BossTransform);
    public static event FBossDeadNotify OnBossDead;

    [Header("Life settings")]
    public bool isDead = false;
    public bool isCollected = false;
    public GameObject healthBarCanvas;
    public HealthBar bossHealthBar;
    public int bossHealth = 3;
    public BossState bossState;

   

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        remainingDistance = Mathf.Infinity;
    }

    // Start is called before the first frame update
    void Start()
    {
        bossHealthBar.SetMaxHealth(bossHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if(isDead && other.CompareTag("Puerto") && !isCollected)
        {
            isCollected = true;
            GameManager.Instance.SetBossCollected(this);
            Destroy(gameObject);

        }
    }


    public Rigidbody SetHooked(bool IsHooked)
    {
        GetComponent<Collider>().isTrigger = true;

        return GetComponent<Rigidbody>();

    }
 
    void SetDead()
    {
        isDead = true;
        bossState = BossState.DEAD;
        navAgent.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        OnBossDead?.Invoke(transform);
    }
  

    void FollowPlayer()
    {
        if (playerTarget == null) return;


        if (!navAgent.SetDestination(playerTarget.position)) return;

        if (!navAgent.hasPath) return;
        remainingDistance = navAgent.remainingDistance;

    }

    void Brain()
    {
        switch(bossState)
        {
            case BossState.IDLE:

                break;
            case BossState.FOLLOW:
                if (isFollowingPlayer == true)
                {
                    FollowPlayer();
                }
                break;
            case BossState.DEAD:

                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        Brain();

        transform.LookAt(playerTarget);
    }

 

    public void ApplyDamage(int Dmg, EWeaponType weaponType)
    {
        if (weaponType != EWeaponType.Harpoon) return;

        if (bossState == BossState.DEAD) return;

        bossHealth -= Dmg;

        bossHealthBar.SetHealth(bossHealth);



        if (bossHealth <= 0)
        {
            healthBarCanvas.SetActive(false);

            bossHealth = 0;

            SetDead();
        }
       
    }
}
