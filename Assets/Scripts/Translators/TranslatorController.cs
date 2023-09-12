using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Translators
{
    public class TranslatorController : MonoBehaviour
    {
        public static TranslatorController Instance { get; private set; }

        [SerializeField] private AllTranslators allTranslators;

        public AllTranslators AllTranslators => allTranslators;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
                Debug.LogWarning("TranslatorController is not Singleton");
            }
        }
    }
}