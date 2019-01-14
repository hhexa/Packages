using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {

        [SerializeField] List<Item> items = new List<Item>();
        [SerializeField] Transform itemsParent;
        [SerializeField] ItemSlot[] itemSlots;

        private void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

            RefreshUI();
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

        public bool IsFull()
        {
            return items.Count >= itemSlots.Length;
        }
    }
}