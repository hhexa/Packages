using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {

        [SerializeField] private List<Item> items = new List<Item>();
        [SerializeField] Transform itemsParent;
        [SerializeField] ItemSlot[] itemSlots;

        private void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
    }
}