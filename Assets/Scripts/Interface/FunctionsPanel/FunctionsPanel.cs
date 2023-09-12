using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class FunctionsPanel : MonoBehaviour
{
    [Serializable]
    private class FunctionsPanelItemsDict : SerializableDictionaryBase<ComputerFunctions,FunctionsPanelItem>
    {
        
    }

    [SerializeField] private FunctionsPanelItemsDict functionsPanelItemsDict;
    
    private void Awake()
    {
        Computer.Instance.computerFunctionsChanged += OnFunctionsChanged;
    }

    private void OnFunctionsChanged(HashSet<ComputerFunctions> computerFunctionsSet)
    {
        var functionPanelItems = new List<FunctionsPanelItem>();
        foreach (var computerFunction in computerFunctionsSet)
        {
            var functionPanelItem = functionsPanelItemsDict[computerFunction];
            functionPanelItems.Add(functionPanelItem);
            functionPanelItem.ReDraw(true);
        }
        SetAllActive(functionsPanelItemsDict.Values.Except(functionPanelItems), false);
    }

    private void SetAllActive(IEnumerable<FunctionsPanelItem> functionsPanelItems,bool active)
    {
        foreach (var value in functionsPanelItems)
        {
            value.ReDraw(active);
        }
    }
}
