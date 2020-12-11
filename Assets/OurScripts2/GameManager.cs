using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool canPause;
    public CanvasGroup pausePanel;
    public static event FNotify_1Params<BossAIScript> OnBossCollected;

    public WeaponsDatabase weaponsDbReference;

    public static Action<int> OnScoreChange { get; internal set; }
    public static Action<EGameStates> OnGameStateChange { get; internal set; }

    internal void AddScore(int v)
    {
        throw new NotImplementedException();
    }

    internal void SetRoundBegin()
    {
        throw new NotImplementedException();
    }

    internal void AddWinCount(int v)
    {
        throw new NotImplementedException();
    }

    public void NextScene()
    {
        Debug.Log("Next Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
        throw new NotImplementedException();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void SetBossCollected(BossAIScript bossAIScript)
    {

        OnBossCollected?.Invoke(bossAIScript);

    }

   
}
