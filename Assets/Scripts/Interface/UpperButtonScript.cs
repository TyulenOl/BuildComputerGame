using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperButtonScript : MonoBehaviour
{
    [SerializeField] private ComputerPartType type;
    [SerializeField] private UpperPanelLogic upperPanelLogic;
    
    public ComputerPartType Type => type;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => upperPanelLogic.SetActivity(type, transform));
    }
}
