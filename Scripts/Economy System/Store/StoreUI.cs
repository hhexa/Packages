using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Kira.Economy
{
    [RequireComponent(typeof(Store))]
    public class StoreUI : SerializedMonoBehaviour //, ITrader
    {
        [SerializeField] private CanvasGroup slotsCanvas;
        [SerializeField] private Transform slotsParent;

        private List<StoreCommodity> storeStock;
        private StoreSlot[] storeSlots;
        private Store store;
        private StoreInfoUI infoUI;

        private void OnValidate()
        {
            if (store == null)
                store = GetComponent<Store>();

            if (infoUI == null)
                infoUI = GetComponentInChildren<StoreInfoUI>();

            if (slotsCanvas == null)
            {
                slotsCanvas = GetComponent<CanvasGroup>();
            }

            if (slotsParent != null)
            {
                storeSlots = slotsParent.GetComponentsInChildren<StoreSlot>();
                RefreshUI();
            }
        }

        public void RefreshUI()
        {
            storeStock = store.StoreStock;

            int i = 0;

            for (; i < storeStock.Count && i < storeSlots.Length; i++)
            {
                storeSlots[i].gameObject.SetActive(true);

                if (storeStock[i].commodity != null)
                    storeSlots[i].Commodity = storeStock[i].commodity;
            }

            for (; i < storeSlots.Length; i++)
            {
                storeSlots[i].Commodity = null;
            }
        }

        private void Start()
        {
            store.OnStoreClicked += ToggleCanvas;
            store.OnBuyEvent += OnBuy;

            foreach (StoreSlot slot in storeSlots)
            {
                slot.OnRightClickEvent += store.SlotClicked;
                slot.OnLeftClickEvent += ShowItemInfo;
            }
        }

        //Called when an item is baught
        private void OnBuy(StoreCommodity item)
        {
            RefreshUI();
            
            if (item.stock >= 1)
                infoUI.ShowInfo(item);
            else
                infoUI.HideInfo();
        }

        public void ShowItemInfo(Commodity item)
        {
            infoUI.ShowInfo(FindCommodity(item));
        }

        public StoreCommodity FindCommodity(Commodity item)
        {
            foreach (StoreCommodity storeItem in storeStock)
            {
                if (storeItem.commodity == item) return storeItem;
            }
            return null;
        }

        public void ToggleCanvas()
        {
            if (slotsCanvas.alpha == 0f)
            {
                slotsCanvas.alpha = 0.9f;
                slotsCanvas.interactable = true;
                slotsCanvas.blocksRaycasts = true;
            }
            else
            {
                slotsCanvas.alpha = 0f;
                slotsCanvas.interactable = false;
                slotsCanvas.blocksRaycasts = false;
            }
        }
    }
}