using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using DG.Tweening;
using Taller;

public enum EBeginCondition { OnStart, OnRoundBegin, Custom}
public class TimedGoal : SerializedMonoBehaviour
{
    public EBeginCondition beginCondition;

    public float maxTime = 5;
    [ReadOnly]
    public float currentTime = 0;
    public bool incrementalDistancePercent = false;
    [ReadOnly]
    public bool timerIsrunning;
    public UnityEvent OnTimerCompleted;
    //  public FUnityNotify_2Params OnTimerUpdate;
    public static event FNotify_2Params<float, float> OnTimerUpdate;
    private void Start()
    {
        if (beginCondition == EBeginCondition.OnStart)
            BeginTimer();
    }

    private void OnEnable()
    {
        if(beginCondition==EBeginCondition.OnRoundBegin)
            GameManager.OnGameStateChange += GameManager_OnGameStateChange;
    }


    private void OnDisable()
    {
        if (beginCondition == EBeginCondition.OnRoundBegin)
            GameManager.OnGameStateChange -= GameManager_OnGameStateChange;

    }

    private void GameManager_OnGameStateChange(EGameStates state)
    {
        if (state == EGameStates.GAMEPLAY)
            BeginTimer();
    }

    public void BeginTimer()
    {
        DOTween.To(() => currentTime, x => currentTime = x, maxTime, maxTime).OnUpdate( TimerUpdate).OnComplete( TimerCompleted);

    }
 
    void TimerUpdate()
    {
        float percent = currentTime / maxTime;

        if (incrementalDistancePercent)
            percent = 1 - percent;

        OnTimerUpdate?.Invoke(currentTime, percent);

    }
    void TimerCompleted()
    {
        OnTimerCompleted.Invoke();
        GameManager.Instance.SetRoundOver(ERoundWinCondition.RoundTimeCompleted);
    }
}
