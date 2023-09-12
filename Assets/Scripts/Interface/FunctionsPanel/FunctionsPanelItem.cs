using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionsPanelItem : MonoBehaviour
{
      [SerializeField] private Image activeImage;
      [SerializeField] private Image inActiveImage;

      public void ReDraw(bool active)
      {
            activeImage.gameObject.SetActive(active);
            inActiveImage.gameObject.SetActive(!active);
      }
}
