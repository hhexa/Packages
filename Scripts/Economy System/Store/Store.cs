using System;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Kira.Economy
{
    public class Store : SerializedMonoBehaviour, IInteractable
    {
        [SerializeField] private List<StoreCommodity> storeStock = new List<StoreCommodity>();
        private EconomyItem[] storeItems;
        public event Action OnStoreClicked;

        [SerializeField]
        private Renderer[] highlightRenderers;
        private Shader defaultShader;
        private Shader highLightShader;

        public event Action<StoreCommodity> OnBuyEvent;

        private void OnValidate()
        {
            storeItems = GetComponentsInChildren<EconomyItem>();
        }

        private void Start()
        {
            //Store shader on items model and get Outline shader from resources
            defaultShader = highlightRenderers[0].material.shader;
            highLightShader = Shader.Find("Outlined/Uniform");
        }

        public List<StoreCommodity> StoreStock => storeStock;

        public bool Buy(Commodity item)
        {
            foreach (StoreCommodity stock in storeStock)
            {
                if (stock.commodity == item)
                {
                    return stock.Purchase();
                }
            }
            return false;
        }

        public void SlotClicked(Commodity item)
        {
            foreach (StoreCommodity stock in storeStock)
            {
                if (stock.commodity == item)
                {
                    if (PlayerManager.Player.Trader.Buy(item, stock.price))
                    {
                        stock.Purchase();
                        if (OnBuyEvent != null)
                            OnBuyEvent(stock);
                        if (stock.stock <= 0)
                        {
                            RemoveStock(stock);
                        }
                    }
                    break;
                }
            }
        }

        private void RemoveStock(StoreCommodity stock)
        {
            storeStock.Remove(stock);
            if (OnBuyEvent != null)
                OnBuyEvent(stock);
        }

        public void Highlight(bool on)
        {
            Shader currentShader = defaultShader;
            if (on) currentShader = highLightShader;

            foreach (Renderer rend in highlightRenderers)
            {
                rend.material.shader = currentShader;
            }
        }

        public void Click()
        {
            if (OnStoreClicked != null)
            {
                OnStoreClicked();
            }
        }
    }
}