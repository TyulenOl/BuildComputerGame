using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckButtonLogic : MonoBehaviour
{
    private Button button;

    [SerializeField] private RectTransform notWinPanel;
    [SerializeField] private RectTransform winPanel;
    [SerializeField] private RectTransform panels;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var isNeededPartsEmpty = !Computer.Instance.GetNeededFunctions().Any();
        
        winPanel.gameObject.SetActive(isNeededPartsEmpty);
        notWinPanel.gameObject.SetActive(!isNeededPartsEmpty);
        panels.gameObject.SetActive(true);
    }
}
