using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace Kira.InventorySystem
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        protected Image image;
        protected Item _item;

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
            if (image == null)
                image = transform.GetChild(1).GetComponent<Image>();
        }
    }
}