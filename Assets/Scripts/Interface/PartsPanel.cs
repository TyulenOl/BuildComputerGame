using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Interface
{
    public class PartsPanel : MonoBehaviour, IDropHandler
    {
        [SerializeField] private LayoutGroup layoutGroup;

        public void OnDrop(PointerEventData eventData)
        {
            var compPartInfo = eventData.pointerDrag.GetComponent<CompPartInfo>();
            AddVisualPart(compPartInfo);
        }

        public virtual void RemovePart(CompPartInfo computerPartInfo)
        {
            
        }
        public virtual void AddVisualPart(CompPartInfo compPartInfo)
        {
            if(compPartInfo == null) return;
            compPartInfo.gameObject.transform.SetParent(layoutGroup.transform);
            compPartInfo.CurrentPartsPanel = this;
        }
    }
}