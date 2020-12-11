using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DistanceGoal : SerializedMonoBehaviour
{
    [Required("target player is null.")]

    public Transform targetPlayer;

    private float currentDistance;

    public bool incrementalDistancePercent = true;

    public bool useHorizontalDistance = true;

    public static event FNotify_2Params<float, float> OnDistanceChange;


    void CheckHorizontalDistance()
    {
      
            currentDistance = Mathf.Max(0, (transform.position.x - targetPlayer.position.x));
        float percent = currentDistance / transform.position.x;
        if (incrementalDistancePercent)
            percent = 1 - percent;

        OnDistanceChange?.Invoke(currentDistance, percent);

    }

    private void FixedUpdate()
    {
        if (useHorizontalDistance)
            CheckHorizontalDistance();


    }


}
