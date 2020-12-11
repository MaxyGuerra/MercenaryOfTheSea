using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Taller;
using UnityEngine;

public class UISubCanvas : MonoBehaviour
{
    public bool defaultShowContainer;
    public float fadeInTime = 0.2f;
    public float fadeOutTime = 0.2f;

    [Header("Referencia al container")]
    public GameObject container;
    CanvasGroup canvasGroup;
    private void Awake()
    {
        FindCanvas();
    }
    void FindCanvas()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponentInChildren<CanvasGroup>();

        }
        if (container == null)
        {
             if(canvasGroup==null)
            {
                container =transform.GetChild(0).gameObject;
                canvasGroup = container.GetComponent<CanvasGroup>();
            }
            else
            {
                container = canvasGroup.gameObject;
            }

           
        }
       
    }
    protected virtual void OnEnable()
    {
        FindCanvas();
        if(defaultShowContainer==false)
        container?.SetActive(false);
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;

    }



    private void OnDisable()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }
    protected virtual void GameManager_OnGameStateChange(EGameStates NewGameState)
    {
        switch (NewGameState)
        {

            case EGameStates.ROUND_OVER:
                ShowContainer();
                break;

            default: HideContainer(); break;
        }
    }

    protected void ShowContainer()
    {
        container?.SetActive(true);
        canvasGroup?.DOFade(1, fadeInTime);
    }

    protected void HideContainer()
    {
        container?.SetActive(false);
        canvasGroup?.DOFade(0, fadeOutTime);
    }
}
