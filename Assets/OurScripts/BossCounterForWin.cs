using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossCounterForWin : MonoBehaviour
{
    public GameObject firstZone;
    public GameObject secondZone;
    //public GameObject thirdZone;

    public GameObject enemiesFirstZone;
    public GameObject enemiesSecondZone;
    //public GameObject enemiesThirdZone;
    private int numberOfBossesInBase;
    public CanvasGroup canvasWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Boss"))
        {
            numberOfBossesInBase++;

            Destroy(other.gameObject);

            if (numberOfBossesInBase == 1)
            {
                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(firstZone);
                enemiesFirstZone.gameObject.SetActive(true);
            }

            else if (numberOfBossesInBase == 2)
            {

                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(secondZone);
                enemiesSecondZone.gameObject.SetActive(true);
                canvasWin.gameObject.SetActive(true);
            }

            /*else if(numberOfBossesInBase == 3)
            {
                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(enemiesThirdZone);
                enemiesThirdZone.gameObject.SetActive(true);
            }*/

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
