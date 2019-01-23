using System;
using System.Collections.Generic;
using UnityEngine;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace Kira.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        Bag[] bags = new Bag[4];

        private int totalSlots;

        [SerializeField] List<Item> items = new List<Item>();
        [SerializeField] Transform itemsParent;
        [SerializeField] ItemSlot[] itemSlots;

        public event Action<Item> OnItemRightClickedEvent;
        public event Action<Item> OnPointerEnterEvent;
        public event Action OnPointerExitEvent;

        private void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

            RefreshUI();
        }

        private void Start()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
                itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
                itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            }
        }

        private void RefreshUI()
        {
            int i = 0;

            for (; i < items.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = items[i];
            }

            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
            }
        }

        public bool AddItem(Item item)
        {
            if (IsFull())
                return false;

            items.Add(item);
            RefreshUI();
            return true;
        }

        public bool RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                RefreshUI();
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            return items.Count >= itemSlots.Length;
        }

        public int Capacity
        {
            get
            {
                totalSlots = 0;
                foreach (Bag bag in bags)
                {
                    totalSlots += bag.BagSize;
                }
                return totalSlots;
            }
        }
    }
}