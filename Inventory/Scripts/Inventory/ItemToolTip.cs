using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace Kira.InventorySystem
{
    public class ItemToolTip : SerializedMonoBehaviour
    {
        //Item name Text
        [SerializeField] private TextMeshProUGUI _titleText;
        //Stat Text's
        [SerializeField] private TextMeshProUGUI _staminaText;
        [SerializeField] private TextMeshProUGUI _strengthText;
        [SerializeField] private TextMeshProUGUI _intellectText;

        [SerializeField] private Transform statsPanel;
        private RectTransform toolTipRect;

        //The normal height of the tool tip
        private float normalHeight = 222f;
        //The height to only show the items name ( when we dont need to show the items Stats )
        private float onlyNameHeight = 80f;

        public static ItemToolTip instance;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            toolTipRect = GetComponent<RectTransform>();
        }

        private void Start()
        {
            HideToolTip();
        }

        public void ShowToolTip(Item item)
        {
            _titleText.text = item.DisplayName;

            if (item is EquippableItem)
            {
                EquippableItem eqItem = (EquippableItem)item;
                _staminaText.text = $"Stamina {eqItem.StaminaStat.amount.ToString()}";
                _strengthText.text = $"Strength {eqItem.StrengthStat.amount.ToString()}";
                _intellectText.text = $"Intellect {eqItem.IntellectStat.amount.ToString()}";

                toolTipRect.sizeDelta = new Vector2(toolTipRect.sizeDelta.x, normalHeight);
                statsPanel.gameObject.SetActive(true);
            }
            else
            {
                statsPanel.gameObject.SetActive(false);
                toolTipRect.sizeDelta = new Vector2(toolTipRect.sizeDelta.x, onlyNameHeight);
            }

            gameObject.SetActive(true);
        }

        public void HideToolTip() { gameObject.SetActive(false); }
    }
}