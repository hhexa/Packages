using UnityEngine;
using System;

namespace Kira.InventorySystem
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] private Transform equipmentSlotsParent;
        [SerializeField] private EquipmentSlot[] equipmentSlots;

        public event Action<Item> OnItemRightClickedEvent;

        private void OnValidate()
        {
            if (equipmentSlotsParent != null)
                equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
        }

        private void Start()
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
            }
        }

        public bool AddItem(EquippableItem item, out EquippableItem previousItem)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                //Check if the item's equipment type matches the slots the equipment type
                if (item.EquipmentType == equipmentSlots[i].equipmentType)
                {
                    previousItem = (EquippableItem)equipmentSlots[i].Item;
                    equipmentSlots[i].Item = item;
                    return true;
                }
            }
            previousItem = null;
            return false;
        }

        public bool RemoveItem(EquippableItem item)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                //Check if the item's equipment type matches the slots the equipment type
                if (equipmentSlots[i].Item == item)
                {
                    equipmentSlots[i].Item = null;
                    return true;
                }
            }
            return false;
        }
    }
}