using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdateGoalByTime : MonoBehaviour
{
    [Required("Distance bar is not assigned")]
    public Image timerImageFill;
    [Required("distancetext   is not assigned")]
    public TextMeshProUGUI timerText;

    public bool useIntegerDistance = true;
    private void OnEnable()
    {
        TimedGoal.OnTimerUpdate += TimedGoal_OnTimerUpdate;
     }

    private void TimedGoal_OnTimerUpdate(float Value, float Percent)
    {
        timerImageFill.fillAmount = Percent;
        timerText?.SetText((useIntegerDistance ? Mathf.RoundToInt(Value) : Value).ToString());

    }

    private void OnDisable()
    {
         TimedGoal.OnTimerUpdate -= TimedGoal_OnTimerUpdate;


    }
      
}
