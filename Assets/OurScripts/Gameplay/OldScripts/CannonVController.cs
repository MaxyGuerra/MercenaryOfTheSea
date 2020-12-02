using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonVController : MonoBehaviour
{

    public float cadence = 3;
    private float counter;
    public PlayerController playerReference;

    public Transform cannonVFirePoint;
    public bool isShootingCannonV= false;
    public BulletController cannonVBullet;
    public float CannonVBulletSpeed;

    public AudioClip shootSound;
    AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundShoot()
    {
        _audioSource.PlayOneShot(shootSound);
    }


    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            if (isShootingCannonV)
            {
                counter = cadence;
                BulletController newBullet = Instantiate(cannonVBullet, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0)) as BulletController;

                newBullet.bulletSpeed = CannonVBulletSpeed;

                PlaySoundShoot();
            }

            else
            {
                isShootingCannonV = false;

                counter = 0;
            }


        }
    }
}
