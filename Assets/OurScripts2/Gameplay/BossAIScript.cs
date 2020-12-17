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
    private bool isDead = false;
    private bool isCollected = false;
    public GameObject healthBarCanvas;
    public HealthBar bossHealthBar;
    private float bossHealth;
    public BossState bossState;
    bool shouldBeHooked;
    public GameObject tentaculos;
    public GameObject armature;
    private AttributeBase EnemyHealthAttribute;



    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        EnemyHealthAttribute = GetComponent<AttributeBase>();
        remainingDistance = Mathf.Infinity;
    }

    // Start is called before the first frame update
    void Start()
    {
       //bossHealthBar.SetMaxHealth(bossHealth);
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

    /// <summary>
    /// esto detecta un game over se suscribe a lo que hace el game over del game manager
    /// 
    /// </summary>
    void OnDisable()
    {
        GameManager.OnGameStateChangeEvent -= GameManager_OnGameStateChangeEvent;

    }
    void OnEnable()
    {
        GameManager.OnGameStateChangeEvent += GameManager_OnGameStateChangeEvent;
    }

    private void GameManager_OnGameStateChangeEvent(EGameStates Param1)
    {
        switch (Param1)
        {
            case EGameStates.MAIN_MENU:
                break;
            case EGameStates.CONNECTING:
                break;
            case EGameStates.RELOADING_TO_CHECKPOINT:
                ///realod
                ResetBossToCheckpointState();
                break;
            case EGameStates.LOADING_NEXTROUND:
                break;
            case EGameStates.LOADING_REMATCH:
                break;
            case EGameStates.GAMEPLAY:
                break;
            case EGameStates.ROUND_OVER:
                break;
            case EGameStates.GAME_OVER:

                //no hago?
                break;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    void ResetBossToCheckpointState()
    {
        shouldBeHooked = true;
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
  
    void HookAgain()
    {
        OnBossDead?.Invoke(transform);
        shouldBeHooked = false;
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

        bossHealth = EnemyHealthAttribute.currentValue;
        bossHealthBar.SetHealth(bossHealth);

    }

 

    public void ApplyDamage(float Dmg, EWeaponType weaponType)
    {
        if (weaponType != EWeaponType.Harpoon) return;

        if (bossState == BossState.DEAD)
        {
            if (shouldBeHooked)
                HookAgain();
            return;
        }
        
        EnemyHealthAttribute.SubtractToValue(Dmg);

        //bossHealthBar.SetHealth(bossHealth);

        if (EnemyHealthAttribute.currentValue <= 0)
        {
            healthBarCanvas.SetActive(false);

            tentaculos.SetActive(false);

            armature.SetActive(false);

            SetDead();
        }
       
    }
    
}