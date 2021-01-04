using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchTrigger : MonoBehaviour
{
    public AudioClip bossTrack;

    public AudioClip exploringTrack;

    private BossAIScript bossReference;

    private AudioManagerScript theAM;
    // Start is called before the first frame update
    private void Awake()
    {
        theAM = FindObjectOfType<AudioManagerScript>();

        bossReference = FindObjectOfType<BossAIScript>();
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
}
