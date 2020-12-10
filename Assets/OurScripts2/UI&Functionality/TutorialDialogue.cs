using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class TutorialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public NewPlayerController playerReference;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public float skipTime = 1f;
    bool bCanSkip;
    [Header("Dialogue reaction")]

    public EPlayerActions endingAction;
    public bool useTriggerToBegin = true;
    public bool dialogueIsPlaying;

    private bool isWaitingForInput;
    private Coroutine typeCorutine;//variable que almacena la corutina

    void Start()
    {
      
        if(!useTriggerToBegin)
        { BeginDialogue(); }
      

    }

    void BeginDialogue()
    {
        playerReference.canMove = false;
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
    private void OnEnable()
    {
         
        NewPlayerController.OnPlayerActionActivate += PlayerController_OnPlayerActionActivate;
    }
    private void OnDisable()
    {
        NewPlayerController.OnPlayerActionActivate -= PlayerController_OnPlayerActionActivate;
    }
    private void PlayerController_OnPlayerActionActivate(EPlayerActions currentAction)
    {
        print(currentAction);
        if (!isWaitingForInput) return;
        if (endingAction == EPlayerActions.NONE) return;
        if (endingAction != currentAction) return;

        
            endingAction = EPlayerActions.NONE;
            NewPlayerController.OnPlayerActionActivate -= PlayerController_OnPlayerActionActivate;
            EndDialogue();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!useTriggerToBegin) return;
        if (other.CompareTag("Player"))
            BeginDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
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

        if (index >= sentences.Length-1)
            isWaitingForInput = true;
        else
        bCanSkip = true;
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
            if(index == 2)
            {
                playerReference.canMove = true;
            }

            textDisplay.text = "";
            typeCorutine = StartCoroutine(Type());
        }

      
    }
}