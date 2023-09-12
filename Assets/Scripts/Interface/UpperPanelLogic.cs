using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class UpperPanelLogic : MonoBehaviour
{
    [SerializeField] private RectTransform YellowButtonTransform;
    
    [System.Serializable]
    private class FunctionsRectTransformDict : SerializableDictionaryBase<ComputerPartType,RectTransform>
    {
        
    }

    [SerializeField] private FunctionsRectTransformDict functionsPanelItemsDict;

    [SerializeField] private RectTransform oldPart;

    public void SetActivity(ComputerPartType type, Transform trnsfrm)
    {
        if(oldPart != null)
            oldPart.gameObject.SetActive(false);
        var newPart = functionsPanelItemsDict[type];
        oldPart = newPart;
        newPart.gameObject.SetActive(true);
        YellowButtonTransform.position = trnsfrm.position;
    }
}
