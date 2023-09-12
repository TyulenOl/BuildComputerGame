using System.Collections.Generic;
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
                    answer += $"{TranslateComputerFunction(function)}, ";
                }

                answer.Remove(answer.Length - 2);
                answer += ".";
                return answer;
            } 
        }
        
        public string TranslateExtraFunctions(IReadOnlyList<ComputerFunctions> computerFunctionsList)
        {
            if (computerFunctionsList.Count == 0)
                return "";
            
            foreach (var need in extraTranslator)
                if (need.TryTranslate(computerFunctionsList, out var text))
                    return text;

            return GetUniversalNeededAnswer();
            
            string GetUniversalNeededAnswer()
            {
                var answer = "Лишнее : ";
                foreach (var function in computerFunctionsList)
                {
                    answer += $"{TranslateComputerFunction(function)}, ";
                }

                answer.Remove(answer.Length - 2);
                answer += ".";
                return answer;
            } 
        }
    }
}