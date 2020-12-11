using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Taller;
using UnityEngine;

public class UIRoundOverSubCanvas : UISubCanvas
{
    protected override void GameManager_OnGameStateChange(EGameStates NewGameState)
    {
        switch (NewGameState)
        {

            case EGameStates.ROUND_OVER:
                ShowContainer();
                break;

            default: HideContainer(); break;
        }
  
    }


}