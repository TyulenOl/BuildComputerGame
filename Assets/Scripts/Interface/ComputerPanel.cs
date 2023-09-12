using Translators;
using UnityEngine;

namespace Interface
{
    public class ComputerPanel : PartsPanel
    {
        private AllTranslators allTranslators => TranslatorController.Instance.AllTranslators;
        
        public void AddPart(ComputerPart computerPart, out Callback callback)
        {
            Computer.Instance.AddPart(computerPart, out callback);
            if (callback != null)
            {
                var text = "Что то не так";
                if (callback is ExtraFunctions extra)
                {
                    text = allTranslators.TranslateExtraFunctions(extra);
                }
                else if (callback is FunctionDuplication func)
                {
                    text = allTranslators.TranslateFunctionDuplications(func);
                }
                else if (callback is PartDuplication part)
                {
                    text = allTranslators.TranslatePartDuplication(part);
                }
                
                ExceptionPanel.Instance.ReDrawException(text);
            }
        }

        public override void RemovePart(CompPartInfo computerPartInfo)
        {
            Computer.Instance.RemovePart(computerPartInfo.ComputerPartData);
        }

        public override void AddVisualPart(CompPartInfo compPartInfo)
        {
            AddPart(compPartInfo.ComputerPartData, out var callback);
            if(callback != null) return;
            base.AddVisualPart(compPartInfo);
        }
    }
}