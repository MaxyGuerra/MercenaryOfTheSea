using System.Collections;
using System.Collections.Generic;
using Taller;
using UnityEngine;

public class UIMainMenuSubCanvas : UISubCanvas
{
   
    protected override void GameManager_OnGameStateChange(EGameStates NewGameState)
    {
        switch (NewGameState)
        {

            case EGameStates.MAIN_MENU:
                ShowContainer();
                break;

            default: HideContainer(); break;
        }
    }

    public void BeginGameplayCall()
    {
        GameManager.Instance?.SetRoundBegin();
    }
}
