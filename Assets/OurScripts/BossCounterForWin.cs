using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossCounterForWin : MonoBehaviour
{
    public GameObject firstZone;
    public GameObject secondZone;
    //public GameObject thirdZone;
    public GameObject roadToSecondZone;
    public GameObject roadToThirdZone;
    public GameObject enemiesSecondZone;
    public GameObject enemiesThirdZone;
    //public GameObject enemiesThirdZone;
    private int numberOfBossesInBase;
    public CanvasGroup canvasWin;
    public GameObject firstCatchIcon;
    public GameObject secondCatchIcon;
    public GameObject thirdCatchIcon;

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
                enemiesSecondZone.gameObject.SetActive(true);
                firstCatchIcon.gameObject.SetActive(true);
                roadToSecondZone.gameObject.SetActive(true);

            }

            else if (numberOfBossesInBase == 2)
            {

                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(secondZone);
                enemiesThirdZone.gameObject.SetActive(true);
                secondCatchIcon.gameObject.SetActive(true);
                roadToThirdZone.gameObject.SetActive(true);
            }

            else if (numberOfBossesInBase == 3)
            {
                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");

                thirdCatchIcon.gameObject.SetActive(true);

                Time.timeScale = 0;
                canvasWin.gameObject.SetActive(true);
            }

        }
    }
   
}
