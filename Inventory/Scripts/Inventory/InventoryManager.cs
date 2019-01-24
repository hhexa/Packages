using UnityEngine;
using Kira.Characters;

namespace Kira.InventorySystem
{
    /// <summary>
    ///Manages interactions between the inventory
    /// and the equipment panel
    ///</summary>

    public class InventoryManager : MonoBehaviour
    {

        [SerializeField] protected Inventory inventory;
        [SerializeField] protected EquipmentPanel equipmentPanel;
        [SerializeField] PlayerStats statsManager;
        [SerializeField] private ItemToolTip itemToolTip;

        //<summary>
        //Equipping Items from the Inventory to the Equipment Panel
        //If the Equipment Slot already has an Item then Replace the Item
        //And then place the replaced item back in the inventory
        //</summary>

        protected virtual void Awake()
        {
            inventory.OnItemRightClickedEvent += EquipFromInventory;
            equipmentPanel.OnItemRightClickedEvent += UnEquipFromEquipPanel;

            // Add Listeners on StatManager class
            inventory.OnItemRightClickedEvent += statsManager.OnItemEquip;
            equipmentPanel.OnItemRightClickedEvent += statsManager.OnItemUnEquip;

        }

        private void Start()
        {
            //Get item tool tip
            itemToolTip = ItemToolTip.instance;

            //Tool tip listeners
            inventory.OnPointerEnterEvent += ShowToolTip;
            inventory.OnPointerExitEvent += HideToolTip;
            equipmentPanel.OnPointerEnterEvent += ShowToolTip;
            equipmentPanel.OnPointerExitEvent += HideToolTip;
        }

        private void ShowToolTip(Item item)
        {
            itemToolTip.ShowToolTip(item);
        }

        private void HideToolTip()
        {
            itemToolTip.HideToolTip();
        }

        protected virtual void EquipFromInventory(Item item)
        {
            if (item is EquippableItem)
            {
                Equip((EquippableItem)item);
            }
        }

        protected virtual void UnEquipFromInventory(Item item)
        {
            if (item is EquippableItem)
            {
                UnEquip((EquippableItem)item);
            }
        }

        protected virtual void EquipFromEquipPanel(Item item)
        {
            if (item is EquippableItem)
            {
                Equip((EquippableItem)item);
            }
        }

        protected virtual void UnEquipFromEquipPanel(Item item)
        {
            if (item is EquippableItem)
            {
                UnEquip((EquippableItem)item);
            }
        }

        public virtual void Equip(EquippableItem item)
        {
            HideToolTip();

            if (inventory.RemoveItem(item))
            {
                EquippableItem previousItem;

                if (equipmentPanel.AddItem(item, out previousItem))
                {
                    //If the equip slot already has an item
                    if (previousItem != null)
                    {
                        //Removes previous Items Stats from Character
                        statsManager.OnItemUnEquip(previousItem);

                        //Add that item to the inventory
                        inventory.AddItem(previousItem);
                        ShowToolTip(previousItem);
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

        public virtual void UnEquip(EquippableItem item)
        {
            HideToolTip();
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
            }
        }
    }
}