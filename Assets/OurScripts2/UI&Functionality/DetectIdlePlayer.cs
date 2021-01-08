using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectIdlePlayer : MonoBehaviour
{
    
    public EPlayerActions currentPlayerAction = EPlayerActions.NONE;
    public UnityEvent onPlayerIdle;
    public UnityEvent onPlayerMove;
    private void OnEnable()
    {
        NewPlayerController.OnPlayerActionActivate += NewPlayerController_OnPlayerActionActivate;
    }

    private void OnDisable()
    {
        NewPlayerController.OnPlayerActionActivate -= NewPlayerController_OnPlayerActionActivate;
    }


    private void NewPlayerController_OnPlayerActionActivate(EPlayerActions currentAction)
    {
        if(currentAction == EPlayerActions.Idle && currentPlayerAction!= EPlayerActions.Idle)
        {
            currentPlayerAction = EPlayerActions.Idle;
            onPlayerIdle.Invoke();
        } 

        if(currentAction == EPlayerActions.PlayerMove && currentPlayerAction != EPlayerActions.PlayerMove)
        {
            currentPlayerAction = EPlayerActions.PlayerMove;
            onPlayerMove.Invoke();
        }
    }
}
