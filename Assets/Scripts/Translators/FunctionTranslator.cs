using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Translators
{
    [CreateAssetMenu(menuName = "Translators/Create FunctionTranslator", fileName = "New FunctionTranslator", order = 51)]
    public class FunctionTranslator: ScriptableObject
    {
        [System.Serializable]
        private class FunctionStringDictionary : SerializableDictionaryBase<ComputerFunctions, string> {}

        [SerializeField] private FunctionStringDictionary translatorDictionary;

        public bool TryTranslate(ComputerFunctions function, out string value)
        {
            return translatorDictionary.TryGetValue(function, out value);
        }
    }
}