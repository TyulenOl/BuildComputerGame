using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Translators
{
    [CreateAssetMenu(menuName = "Translators/Create ComputerPartTranslator", fileName = "New ComputerPartTranslator", order = 51)]
    public class ComputerPartTranslator: ScriptableObject
    {
        [System.Serializable]
        private class ComputerPartStringDictionary : SerializableDictionaryBase<ComputerPartType, string> {}

        [SerializeField] private ComputerPartStringDictionary translatorDictionary;

        public bool TryTranslate(ComputerPartType computerPartType, out string value)
        {
            return translatorDictionary.TryGetValue(computerPartType, out value);
        }
    }
}