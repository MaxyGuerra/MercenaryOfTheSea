using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCController : MonoBehaviour
{
    public float cadence = 3;
    private float counter;
    public PlayerController playerReference;

    public Transform cannonCFirePoint;
    public bool isShootingCannonC = false;
    public BulletController cannonCBullet;
    public float CannonCBulletSpeed;

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
            if (isShootingCannonC)
            {
                counter = cadence;

                BulletController newBullet = Instantiate(cannonCBullet, transform.position, transform.rotation * Quaternion.Euler(0, -90, 0)) as BulletController;
                newBullet.bulletSpeed = CannonCBulletSpeed;

                PlaySoundShoot();
            }

            else
            {
                isShootingCannonC = false;

                counter = 0;
            }


        }
    }
}

