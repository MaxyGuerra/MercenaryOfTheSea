using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerControllerInput : MonoBehaviour
{
     

    public UnityEvent OnFire1ButtonDown,OnFire1ButtonHold, OnFire1ButtonUp, OnQButtonDown, OnEButtonDown;
    public FUnityNotify_2Params OnAxisChange;
    void ReadInput()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");

        OnAxisChange.Invoke(horizontalValue, verticalValue);

       if (Input.GetButtonDown("Fire1"))
        {
            OnFire1ButtonDown.Invoke();
            return;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            OnFire1ButtonUp.Invoke();
            return;
        }
        if (Input.GetButton("Fire1"))
        {
            OnFire1ButtonHold.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnQButtonDown.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnEButtonDown.Invoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
}
