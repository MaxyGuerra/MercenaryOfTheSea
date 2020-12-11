using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UIAttributeListener : SerializedMonoBehaviour
{
    public string AttributeName;
    public TextMeshProUGUI attributeText;
    public Image percentBarFill;

    public bool TransformFloatToInt = true;
    private string textToDisplay;


    private void OnDisable()
    {
        AttributeBase.OnAttributeChangeWithPercentInternal -= AttributeBase_OnAttributeChangeWithPercentInternal;
    }

    private void OnEnable()
    {
        AttributeBase.OnAttributeChangeWithPercentInternal += AttributeBase_OnAttributeChangeWithPercentInternal;
    }

    private void AttributeBase_OnAttributeChangeWithPercentInternal(string Param1, float Param2, float Param3)
    {
        if (AttributeName != Param1) return;

        SetTextValueWithPercent(Param2, Param3);
    }

    public void SetTextValue(float Value)
    {
        if (TransformFloatToInt)
            textToDisplay = Mathf.RoundToInt(Value).ToString();
        else
            textToDisplay = Value.ToString();

        attributeText?.SetText(textToDisplay);

    }
    public void SetTextValueWithPercent(float Value,float percent)
    {
        SetTextValue(Value);

        if(percentBarFill!=null)
        percentBarFill.fillAmount=percent;
    }


}
