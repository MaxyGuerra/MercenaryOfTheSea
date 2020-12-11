using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;

public class UIUpdateByDastanceToGoal : SerializedMonoBehaviour
{
    [Required("Distance bar is not assigned")]
    public Image distanceBarFill;
    [Required("distancetext   is not assigned")]
    public TextMeshProUGUI distancetext;

    public bool useIntegerDistance = true;
    private void OnEnable()
    {

        DistanceGoal.OnDistanceChange += DistanceGoal_OnDistanceChange;
    }
     
    private void OnDisable()
    {
        DistanceGoal.OnDistanceChange -= DistanceGoal_OnDistanceChange;


    }
    private void DistanceGoal_OnDistanceChange(float Distance, float Percent)
    {
        distanceBarFill.fillAmount = Percent;
        distancetext?.SetText((useIntegerDistance ? Mathf.RoundToInt(Distance) : Distance).ToString());

    }

}
