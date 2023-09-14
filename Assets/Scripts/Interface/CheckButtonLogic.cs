using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface;
using Translators;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckButtonLogic : MonoBehaviour
{
    private Button button;
    
    [SerializeField] private RectTransform winPanel;
    [SerializeField] private RectTransform panels;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var neededParts = Computer.Instance.GetNeededFunctions().ToList();
        var isNeededPartsEmpty = !neededParts.Any();

        winPanel.gameObject.SetActive(isNeededPartsEmpty);
        if (isNeededPartsEmpty)
        {
            ExceptionPanel.Instance.gameObject.SetActive(false);
            ScormController.Instance.SaveScore(true);
        }
        else
        {
            var str = "Вы не добавили всех нужных компонентов. \n";
            var addStr =
                TranslatorController.Instance.AllTranslators.TranslateNeededFunctions(neededParts);
            ExceptionPanel.Instance.ReDrawException(str + addStr);
            ScormController.Instance.SaveScore(false);
        }
        panels.gameObject.SetActive(true);
    }
}
