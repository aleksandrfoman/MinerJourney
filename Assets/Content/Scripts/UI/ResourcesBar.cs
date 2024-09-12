using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI
{
    public class ResourcesBar : MonoBehaviour
    {
        [SerializeField] private Transform header;
        [SerializeField] private Image imageFill;
        
        public void BarFill(float value)
        {
            imageFill.DOFillAmount(value, 0.1f);
        }
        
        public void EnableBar(bool value)
        {
            if (value)
            {
                gameObject.SetActive(true);
                header.localScale = Vector3.zero;
                header.DOScale(Vector3.one, 0.2f);
            }
            else
            {
                header.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
            }
        }
    }
}
