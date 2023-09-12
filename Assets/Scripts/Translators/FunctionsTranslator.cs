using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Translators
{
    [CreateAssetMenu(menuName = "Translators/Create FunctionsTranslator", fileName = "New FunctionsTranslator", order = 51)]
    public class FunctionsTranslator: ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private List<ComputerFunctions> functions;
        [SerializeField, TextArea] protected string text;

        protected HashSet<ComputerFunctions> functionsSet;

        public bool TryTranslate(IEnumerable<ComputerFunctions> neededFunctions, out string text)
        {
            text = "";
            if (neededFunctions.All(x => functionsSet.Contains(x)))
            {
                text = this.text;
                return true;
            }

            return false;
        }
        
        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            functionsSet = new HashSet<ComputerFunctions>(functions);
        }
    }
}