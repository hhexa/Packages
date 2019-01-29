using System;
using UnityEngine;
using TMPro;

namespace Kira.Economy
{
    public class EconomyItem : MonoBehaviour, IInteractable
    {
        private Renderer itemRenderer;
        private Shader defaultShader;
        private Shader highLightShader;
        private TextMeshPro itemtext;

        [SerializeField]
        private Commodity commodity;
        public Commodity GetCommodity() => commodity;

        public Action<EconomyItem> OnPurchasedEvent;

        private void Start()
        {
            itemtext = transform.GetComponentInChildren<TextMeshPro>();
            itemtext.gameObject.SetActive(false);

            itemRenderer = transform.GetComponentInChildren<Renderer>();

            //Store shader on items model and get Outline shader from resources
            defaultShader = itemRenderer.material.shader;
            highLightShader = Shader.Find("Outlined/Uniform");
        }

        public void Highlight(bool on)
        {
            if (on)
            {
                itemRenderer.material.shader = highLightShader;
            }
            else if (!on)
            {
                itemRenderer.material.shader = defaultShader;
            }

            itemtext.text = commodity.ToString();
            itemtext.gameObject.SetActive(on);
        }

        public void Click()
        {
            if (OnPurchasedEvent != null)
                OnPurchasedEvent(this);
        }
    }
}