using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossTextTutorial : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public CanvasGroup winText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public float skipTime = 1f;
    bool bCanSkip;

    public LineRenderer hookLineReference;
    [Header("Dialogue reaction")]

    public bool dialogueIsPlaying;
    public GameObject enemies;
    public GameObject newZone;
    private int numberOfBossesInBase = 0;
    private Coroutine typeCorutine;//variable que almacena la corutina

    void Start()
    {

    }

    void BeginDialogue()
    {

        if (dialogueIsPlaying) return;
        textDisplay.transform.parent.gameObject.SetActive(true);
        dialogueIsPlaying = true;
        typeCorutine = StartCoroutine(Type());//guardas la corutina en uan variable para detenerla despues
        print(gameObject);


    }

    void EndDialogue()
    {
        textDisplay.text = " ";

        textDisplay.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator Type()
    {
        StartCoroutine(BlockButton());
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    IEnumerator BlockButton()
    {
        bCanSkip = false;
        yield return new WaitForSeconds(skipTime);
        bCanSkip = true;
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Boss"))
        {

            BeginDialogue();
            numberOfBossesInBase++;

            Destroy(other.gameObject);
            hookLineReference.gameObject.SetActive(false);

            if (numberOfBossesInBase == 1)
            {
                Debug.Log("There are" + " " + numberOfBossesInBase + " " + "Bosses" + " " + "in base");
                Destroy(newZone);
                enemies.gameObject.SetActive(true);
            }

            else if(numberOfBossesInBase == 2)
            {
                winText.gameObject.SetActive(true);
            }
   
        }
    }
  

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && bCanSkip)///bCanSkip es el freno
        {
            NextSentence();
        }

    }

    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            typeCorutine = StartCoroutine(Type());
        }

        else
        {
            EndDialogue();

            hookLineReference.gameObject.SetActive(true);
        }
    }
}
