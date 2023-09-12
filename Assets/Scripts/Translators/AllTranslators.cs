using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Translators
{
    [CreateAssetMenu(menuName = "Create AllTranslators", fileName = "New AllTranslators", order = 51)]
    public class AllTranslators: ScriptableObject
    {
        [SerializeField] private ComputerPartTranslator computerPartTranslator;
        [SerializeField] private FunctionTranslator functionTranslator;
        [SerializeField] private List<FunctionsTranslator> neededTranslator;
        [SerializeField] private List<FunctionsTranslator> extraTranslator;

        public string TranslateComputerPart(ComputerPartType computerPartType)
        {
            if (computerPartTranslator.TryTranslate(computerPartType, out var value))
                return value;
            return "Часть по-умолчанию";
        }
        
        public string TranslateComputerFunction(ComputerFunctions computerFunction)
        {
            if (functionTranslator.TryTranslate(computerFunction, out var value))
                return value;
            return "Функция по-умолчанию";
        }
        
        public string TranslateNeededFunctions(IReadOnlyList<ComputerFunctions> computerFunctionsList)
        {
            if (computerFunctionsList.Count == 0)
                return "Вам всего хватает";
            foreach (var need in neededTranslator)
                if (need.TryTranslate(computerFunctionsList, out var text))
                    return text;

            return GetUniversalNeededAnswer();
            
            string GetUniversalNeededAnswer()
            {
                var answer = "Вам не хватает: ";
                foreach (var function in computerFunctionsList)
                {
                    answer += $"{TranslateComputerFunction(function).ToLower()}, ";
                }

                answer = answer.Remove(answer.Length - 2);
                answer += ".";
                return answer;
            } 
        }
        
        public string TranslateFunctionDuplications(FunctionDuplication functionDuplication)
        {
            var functionsList = functionDuplication.Value.ToList();
            return GetUniversalAnswer();
            
            string GetUniversalAnswer()
            {
                var answer = "Нельзя добавить в конфигурацию устройства с дублирущимися функциями: ";
                foreach (var function in functionsList)
                {
                    answer += $"{TranslateComputerFunction(function).ToLower()}, ";
                }

                answer = answer.Remove(answer.Length - 2);
                answer += ". ";
                return answer;
            } 
        }
        
        public string TranslatePartDuplication(PartDuplication partDuplication)
        {
            return GetUniversalAnswer();
            
            string GetUniversalAnswer()
            {
                var answer = $"Вы попытались добавить в конфигурацию устройство типа {TranslateComputerPart(partDuplication.ExtraPart.Type).ToLower()} - \"{partDuplication.ExtraPart.Name}\"." +
                             $" Это невозможно, потому что у вас уже есть устройство данного типа - {TranslateComputerPart(partDuplication.ExistingPart.Type).ToLower()} - \"{partDuplication.ExistingPart.Name}\"";
                return answer;
            } 
        }
        
        public string TranslateExtraFunctions(ExtraFunctions extraFunctions)
        {
            var computerFunctionsList = extraFunctions.Value;
            if (computerFunctionsList.Count == 0)
                return "";
            
            foreach (var need in extraTranslator)
                if (need.TryTranslate(computerFunctionsList, out var text))
                    return text;

            return GetUniversalNeededAnswer();
            
            string GetUniversalNeededAnswer()
            {
                var answer = $"У добавляемого обьекта {TranslateComputerPart(extraFunctions.Part.Type)} есть лишние функции: ";
                foreach (var function in computerFunctionsList)
                {
                    answer += $"{TranslateComputerFunction(function).ToLower()}";
                }

                answer = answer.Remove(answer.Length - 2);
                answer += ". Постарайтесь избежать лишних функций, приборы с большим числом функций в реальной жизни стоят дороже.";
                return answer;
            } 
        }
    }
}