using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace Kira.InventorySystem
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        protected Image image;
        protected Item _item;
        protected bool refreshOnValidate;

        public Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                if (_item == null)
                {
                    image.enabled = false;
                }
                else
                {
                    image.sprite = _item.Icon;
                    image.enabled = true;
                }
            }
        }

        public event Action<Item> OnRightClickEvent;
        public event Action<Item> OnPointerEnterEvent;
        public event Action OnPointerExitEvent;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Item != null)
            {
                OnPointerEnterEvent?.Invoke(Item);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (Item != null)
            {
                OnPointerExitEvent?.Invoke();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
            {
                if (Item != null && OnRightClickEvent != null)
                {
                    OnRightClickEvent(Item);
                }
            }
        }

        protected virtual void OnValidate()
        {
            if (refreshOnValidate == false)
            {
                return;
            }

            if (image == null)
            {
                image = transform.GetChild(1).GetComponent<Image>();
            }
        }
    }
}