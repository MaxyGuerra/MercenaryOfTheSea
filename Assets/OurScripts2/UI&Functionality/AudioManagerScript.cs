using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : Singleton<AudioManagerScript>
{

    public AudioSource backgroundMusic;
 

    public void ChangeBGMusic (AudioClip music)
    {
        if(backgroundMusic.clip.name == music.name)
        {
            return;
        }

        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }

}
