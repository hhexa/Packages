using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Kira.Economy
{
    public class StoreSlot : MonoBehaviour, IPointerClickHandler
    {
        public Image itemIcon;

        private Commodity commodity;
        public Commodity Commodity
        {
            get
            {
                return commodity;
            }
            set
            {
                commodity = value;
                if (commodity == null)
                {
                    itemIcon.enabled = false;
                }
                else
                {
                    itemIcon.sprite = commodity.Icon;
                    itemIcon.enabled = true;
                }
            }
        }

        public event Action<Commodity> OnRightClickEvent;
        public event Action<Commodity> OnLeftClickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData != null && Commodity != null)
            {
                if (eventData.button == PointerEventData.InputButton.Right && OnRightClickEvent != null)
                {
                    OnRightClickEvent(Commodity);
                }
                else if (eventData.button == PointerEventData.InputButton.Left && OnLeftClickEvent != null)
                {
                    OnLeftClickEvent(Commodity);
                }
            }
        }

        private void OnValidate()
        {
            if (itemIcon == null)
                itemIcon = transform.GetChild(1).GetComponent<Image>();
        }
    }
}