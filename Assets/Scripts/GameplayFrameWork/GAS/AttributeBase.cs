using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class AttributeBase : MonoBehaviour
{
    public string AttributeName;
    public float baseValue=1;
    public float minValue = 0;

    [ReadOnly]
    public float currentValue;

    public FUnityNotify_1Params  OnAttributeChange, OnAttributeInitialized;
    public FUnityNotify_2Params OnAttributeChangeWithPercent;

    public static event FNotify_3Params<string,float, float> OnAttributeChangeWithPercentInternal;
    public UnityEvent OnAttributeDepleted  ;
    public FNotify OnAttributeDepletedEvent;

    private void OnEnable()
    {
        
        InitializeAttribute(baseValue);
    }
    

    public void InitializeAttribute(float NewBaseValue)
    {
        baseValue=currentValue = NewBaseValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();

    }
    public void SetValue(float NewValue)
    {
        currentValue = NewValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();

    }
    public void AddToValue(float NewValue)
    {
        //clamp mantiene valores entre el maximo y el minimo
        currentValue += NewValue;
        currentValue = Mathf.Clamp(currentValue, minValue, baseValue);
        NotifyUI();

        if (currentValue <= minValue)
        {
            OnAttributeDepleted.Invoke();
            OnAttributeDepletedEvent?.Invoke();
        }
          

    }
    public void SubtractToValue(float NewValue)
    {
        AddToValue(-NewValue);

    }

    public void ResetToInitialStats()
    {
        InitializeAttribute(baseValue);
    }
    private void NotifyUI()
    {
        float percent = currentValue / baseValue;
        OnAttributeChange.Invoke(currentValue);

        OnAttributeChangeWithPercent.Invoke(currentValue, percent) ;
        OnAttributeChangeWithPercentInternal?.Invoke(AttributeName,currentValue, percent);
    }



}
