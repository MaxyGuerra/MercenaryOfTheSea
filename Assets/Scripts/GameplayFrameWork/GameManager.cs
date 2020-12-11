using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

 public enum ERoundWinCondition { CompleteTargetWinCount,RoundTimeCompleted,GoalFinish}

namespace Taller
{

    public class GameManager : Singleton<GameManager>
    {
        [Header("Round Status")]
        public ERoundWinCondition RoundWinCondition;
        public int currentRound;
        public int TargetWinCount = 1;
        [ReadOnly]
        public int currentWinCount;
        [Header("Score Units")]
        public int score;

        [Header("Game events")]
        public EGameStates gameStates=EGameStates.GAMEPLAY;

        public UnityEvent OnGameOver, OnRoundOver, OnRoundBegin;


        public static event FNotify_1Params<int> OnScoreChange;
        public static event FNotify_1Params<EGameStates> OnGameStateChange;

        public void SetGameOver()
        {
            ChangeGameState(EGameStates.GAME_OVER);
          
            OnGameOver.Invoke();

        }
        public void SetRoundOver()
        {

            ChangeGameState(EGameStates.ROUND_OVER); 
            OnRoundOver.Invoke();

        }
        public void SetRoundOver(ERoundWinCondition Reason)
        {
            if (Reason != RoundWinCondition) return;

            ChangeGameState(EGameStates.ROUND_OVER);
            OnRoundOver.Invoke();

        }
        public void SetRoundBegin()
        {
            ChangeGameState(EGameStates.GAMEPLAY);

            OnRoundBegin.Invoke();

        }
       
        public void AddScore(int ScoreToAdd)
        {
            score += ScoreToAdd;
            OnScoreChange?.Invoke(score);
        }

        public void ChangeGameState(EGameStates NewGameState)
        {
            gameStates = NewGameState;
            OnGameStateChange?.Invoke(gameStates);



        }
        public void AddWinCount(int WinValue=1)
        {
            if (gameStates != EGameStates.GAMEPLAY) return;

            currentWinCount += WinValue;

            if(currentWinCount>=TargetWinCount && RoundWinCondition==ERoundWinCondition.CompleteTargetWinCount)
            {
                SetRoundOver();
            }
        }
    }
}

