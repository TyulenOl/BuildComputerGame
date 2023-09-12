using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using TMPro;
using Translators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CompPartInfo : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public PartsPanel CurrentPartsPanel { get; set; }
    
    [SerializeField] private ComputerPart computerPartData;
    [SerializeField] private TMP_Text compPartName;
    [SerializeField] private Image compPartImage;

    private PartsPanel oldPartsPanel;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    public ComputerPart ComputerPartData => computerPartData;

    private void Awake()
    {
        compPartName.text = computerPartData.Name;
        compPartImage.sprite = ComputerPartData.Sprite;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        CurrentPartsPanel = GetComponentInParent<PartsPanel>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentPartsPanel != null)
        {
            CurrentPartsPanel.RemovePart(this);
            oldPartsPanel = CurrentPartsPanel;
        }
        transform.SetParent(MainCanvas.Instance.transform);
        canvasGroup.blocksRaycasts = false;
        CurrentPartsPanel = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / MainCanvas.Instance.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (CurrentPartsPanel == null)
        {
            CurrentPartsPanel = oldPartsPanel;
            CurrentPartsPanel.AddVisualPart(this);
        }
    }
}
