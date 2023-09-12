using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsPanel : MonoBehaviour
{
    [SerializeField] private FunctionsPanelItem hearPanelItem;
    [SerializeField] private FunctionsPanelItem seePanelItem;
    [SerializeField] private FunctionsPanelItem speakPanelItem;
    [SerializeField] private FunctionsPanelItem printPanelItem;
    [SerializeField] private FunctionsPanelItem printPaperPanelItem;
    [SerializeField] private FunctionsPanelItem faxPanelItem;
    [SerializeField] private FunctionsPanelItem scanPanelItem;

    private void Awake()
    {
        Computer.Instance.computerFunctionsChanged.AddListener(OnFunctionsChanged);
    }

    private void OnFunctionsChanged(HashSet<ComputerFunctions> computerFunctionsSet)
    {
        var functionPanelItems = new List<FunctionsPanelItem>();
        foreach (var computerFunction in computerFunctionsSet)
        {
            switch (computerFunction)
            {
                    case ComputerFunctions.Hear: 
                        hearPanelItem.ReDraw(true);
                    functionPanelItems.Add(hearPanelItem);
                    break;
                    case ComputerFunctions.Speak:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
                    case ComputerFunctions.See:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
                    case ComputerFunctions.Print:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
                    case ComputerFunctions.PrintPaper:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
                    case ComputerFunctions.Fax:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
                    case ComputerFunctions.Scan:
                    faxPanelItem.ReDraw(true);
                    functionPanelItems.Add(faxPanelItem);
                    break;
            }
        }
    }

    private void SetAllActive( List<FunctionsPanelItem> functionsPanelItems,bool active)
    {
        hearPanelItem.ReDraw(active);
        seePanelItem.ReDraw(active);
        speakPanelItem.ReDraw(active); 
        printPanelItem.ReDraw(active);
        printPaperPanelItem.ReDraw(active); 
        faxPanelItem.ReDraw(active);
        scanPanelItem.ReDraw(active);
    }
}
