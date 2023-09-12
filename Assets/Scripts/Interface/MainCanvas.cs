using System;
using UnityEngine;

namespace Interface
{
    public class MainCanvas : MonoBehaviour
    {
        public static Canvas Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<Canvas>();
            else
            {
                Destroy(this);
                Debug.LogWarning("Main Canvas Duplicated");
            }
        }
    }
}