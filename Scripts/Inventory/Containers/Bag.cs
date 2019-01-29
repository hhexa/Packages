using System;
using UnityEngine;
using System.Collections.Generic;

namespace Kira.InventorySystem
{
    public class Bag : MonoBehaviour, IItem
    {
        [SerializeField]
        protected string displayName;

        //BagSize = Maximum amount of items allowed to be stored in this bag
        [SerializeField]
        protected int bagSize;

        [SerializeField]
        protected Sprite _icon;

        [SerializeField]
        protected List<Item> items = new List<Item>();

        [SerializeField]
        protected int id;

        //Called when an Item is Added or Remov ed.
        public event Action OnBagChangedEvent;

        public bool AddItem(Item item)
        {
            //IF bag is not full
            if (IsFull() == false)
            {
                items.Add(item);

                if (OnBagChangedEvent != null)
                    OnBagChangedEvent();
            }
            return false;
        }

        public bool RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                if (OnBagChangedEvent != null)
                    OnBagChangedEvent();

                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            return items.Count >= BagSize;
        }

        #region getters and setters

        public int BagSize
        {
            get { return bagSize; }
            protected set { bagSize = value; }
        }

        public Sprite Icon
        {
            get { return _icon; }
            protected set { _icon = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            protected set { displayName = value; }
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        #endregion
    }
}