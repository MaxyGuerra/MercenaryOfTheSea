using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class TutorialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public PlayerController playerReference;
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
        
        if (dialogueIsPlaying) return;
        textDisplay.transform.parent.gameObject.SetActive(true);
        playerReference.canMove = false;
        typeCorutine = StartCoroutine(Type());//guardas la corutina en una variable para detenerla despues
        print(gameObject);
        playerReference.canMove = true;


    }

        void EndDialogue()
        {
            
            textDisplay.text = " ";

            textDisplay.transform.parent.gameObject.SetActive(false);
    
        }

    private void OnEnable()
    {
        PlayerController.OnPlayerActionActivate += PlayerController_OnPlayerActionActivate;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerActionActivate -= PlayerController_OnPlayerActionActivate;
    }
    private void PlayerController_OnPlayerActionActivate(EPlayerActions currentAction)
    {
        print(currentAction);
        if (!isWaitingForInput) return;
        if (endingAction == EPlayerActions.NONE) return;
        if (endingAction != currentAction) return;

        
            endingAction = EPlayerActions.NONE;
            PlayerController.OnPlayerActionActivate -= PlayerController_OnPlayerActionActivate;
            EndDialogue();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!useTriggerToBegin) return;
        if (other.CompareTag("Player"))
            BeginDialogue();
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
            textDisplay.text = "";
            typeCorutine = StartCoroutine(Type());
        }

      
    }
}