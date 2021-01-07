using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchTrigger : MonoBehaviour
{
    public AudioClip bossTrack;

    public AudioClip exploringMusic;

    private AudioManagerScript theAM;

    public BossState _bossState = BossState.IDLE;
    private void Awake()
    {
        theAM = FindObjectOfType<AudioManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (bossTrack != null)
            {
                theAM.ChangeBGMusic(bossTrack);
            }
        }
    }

    private void BossAIScript_State(BossState currentAction)
    {
        if (_bossState == BossState.DEAD && _bossState != BossState.IDLE)
        {
            theAM.ChangeBGMusic(exploringMusic);
        }
    }
}
