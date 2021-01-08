using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchTrigger : MonoBehaviour
{
    public AudioClip bossTrack;

    public AudioClip exploringMusic;

    public AudioManagerScript instance;

    public BossState currentBossState = BossState.IDLE;

    private void OnEnable()
    {
        BossAIScript.OnBossDead += BossAIScript_OnBossDead;
    }

    private void BossAIScript_OnBossDead(Transform BossTransform)
    {
      
       instance.ChangeBGMusic(exploringMusic);
      
    }

    private void OnDisable()
    {
          BossAIScript.OnBossDead -= BossAIScript_OnBossDead;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (bossTrack != null)
            {
                instance.ChangeBGMusic(bossTrack);
            }
        }
    }
}
