using System;
using TMPro;
using UnityEngine;

namespace Interface
{
    public class ExceptionPanel: MonoBehaviour
    {
        [SerializeField] private TMP_Text ExceptionText;
        [SerializeField] private RectTransform panels;

        public static ExceptionPanel Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Exception panel is not singleton");
                Destroy(gameObject);
            }
            panels.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        public void ReDrawException(string text)
        {
            ExceptionText.text = text;
            gameObject.SetActive(true);
            panels.gameObject.SetActive(true);
        }
    }
}