using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverSubCanvas : UISubCanvas
{
    protected override void GameManager_OnGameStateChange(EGameStates NewGameState)
    {
        switch (NewGameState)
        {

            case EGameStates.GAME_OVER:
                ShowContainer();
                break;

            default: HideContainer(); break;
        }
    }
}
