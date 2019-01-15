using UnityEngine;

namespace Kira.InventorySystem
{
    // <summary>
    // Manages interactions between the inventory
    // and the equipment panel
    // </summary>

    // [RequireComponent(typeof(StatsManager))]
    // [RequireComponent(typeof(Inventory))]
    // [RequireComponent(typeof(EquipmentPanel))]
    public class InventoryManager : MonoBehaviour
    {

        [SerializeField] Inventory inventory;
        [SerializeField] EquipmentPanel equipmentPanel;
        [SerializeField] StatsManager statsManager;

        //<summary>
        //Equipping Items from the Inventory to the Equipment Panel
        //If the Equipment Slot already has an Item then Replace the Item
        //And then place the replaced item back in the inventory
        //</summary>

        private void Awake()
        {
            inventory.OnItemRightClickedEvent += EquipFromInventory;
            equipmentPanel.OnItemRightClickedEvent += UnEquipFromEquipPanel;

            //Add Listeners on StatManager class
            inventory.OnItemRightClickedEvent += statsManager.OnItemEquip;
            equipmentPanel.OnItemRightClickedEvent += statsManager.OnItemUnEquip;
        }

        private void EquipFromInventory(Item item)
        {
            if (item is EquippableItem)
            {
                Equip((EquippableItem)item);
            }
        }

        private void UnEquipFromInventory(Item item)
        {
            if (item is EquippableItem)
            {
                UnEquip((EquippableItem)item);
            }
        }

        private void EquipFromEquipPanel(Item item)
        {
            if (item is EquippableItem)
            {
                Equip((EquippableItem)item);
            }
        }

        private void UnEquipFromEquipPanel(Item item)
        {
            if (item is EquippableItem)
            {
                UnEquip((EquippableItem)item);
            }
        }

        public void Equip(EquippableItem item)
        {
            if (inventory.RemoveItem(item))
            {
                EquippableItem previousItem;

                if (equipmentPanel.AddItem(item, out previousItem))
                {
                    //If the equip slot already has an item
                    if (previousItem != null)
                    {
                        statsManager.OnItemUnEquip(previousItem);
                        //Add that item to the inventory
                        inventory.AddItem(previousItem);
                    }
                }
                else
                {
                    //If adding item fails for whatever reason, 
                    //Then return it back to the inventory
                    inventory.AddItem(item);
                }
            }
        }

        public void UnEquip(EquippableItem item)
        {
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
            }
        }
    }
}