using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

    public bool canPause;
    public CanvasGroup pausePanel;

    public WeaponsDatabase weaponsDbReference;

    public static Action<int> OnScoreChange { get; internal set; }
    public static Action<EGameStates> OnGameStateChange { get; internal set; }
    public static event FNotify_1Params<EGameStates> OnGameStateChangeEvent;
    public Vector3 LastCheckpoint;


    public static event FNotify_1Params<BossAIScript> OnBossCollected;


    public static event FNotify OnBatteBeging, OnBattleEnd;

    public bool isOnBattle = false;


    internal void AddScore(int v)
    {
        
    }

    internal void SetRoundBegin()
    {
        
    }

    internal void AddWinCount(int v)
    {
       
    }

    public void NextScene()
    {
        Debug.Log("Next Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
    }

    public void GoToInitialMenu()
    {
        Debug.Log("Next Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void ReloadScene()
    {
        Debug.Log("Restart Actual Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Time.timeScale = 1;
        Application.Quit();
    }

    public void PauseGame()
    {
        if(canPause == true)
        {
            pausePanel.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    internal void SetRoundOver(ERoundWinCondition roundTimeCompleted)
    {
         
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void RestartToCheckPoint()
    {
        Time.timeScale = 1;
        ChangeGameState(EGameStates.RELOADING_TO_CHECKPOINT);
    }

    public void ChangeGameState(EGameStates newGameState)
    {
        OnGameStateChangeEvent?.Invoke(newGameState);

      
    }
    public void SaveCheckpoint(Vector3 newCheckPoint)
    {
        LastCheckpoint = newCheckPoint;
    }
    public void SetBossCollected(BossAIScript bossAIScript)
    {

        OnBossCollected?.Invoke(bossAIScript);

    }

    private void Start()
    {
        BeginGame();
    }
    public void BeginGame()
    {
        ChangeGameState(EGameStates.GAMEPLAY);

    }

    public void SetGameOver()
    {

        //TODO si quieren detener el tiempo haganlo aca
        Time.timeScale = 0;
     ChangeGameState(EGameStates.GAME_OVER);

    }

    void SetBattle()
    {
        if(isOnBattle == true)
        {
            
        } 

        else
        {

        }
    }
}
