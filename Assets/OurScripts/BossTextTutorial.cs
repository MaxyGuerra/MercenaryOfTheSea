using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossTextTutorial : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public float skipTime = 1f;
    bool bCanSkip;

    void Start()
    {

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
            StartCoroutine(Type());
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
        }


    }
}
