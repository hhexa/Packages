using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kira.InventorySystem
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType equipmentType;

        protected override void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();
            gameObject.name = equipmentType.ToString() + " Slot";
        }
    }
}