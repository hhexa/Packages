﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace InventorySystem
{
    public class ItemSlot : MonoBehaviour
    {

        [SerializeField]
        private Image image;

        private Item _item;
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

        private void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }

        }
    }
}