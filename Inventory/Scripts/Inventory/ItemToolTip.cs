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
        public static ItemToolTip instance;


        //UI Text variables
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _staminaText;
        [SerializeField] private TextMeshProUGUI _strengthText;
        [SerializeField] private TextMeshProUGUI _intellectText;
        [SerializeField] private Transform statsPanel;

        private Vector2 offset;
        private RectTransform toolTipRect;
        private float normalHeight = 222f;//The normal height of the tool tip
        private float onlyNameHeight = 80f;//The height to only show the items name ( when we dont need to show the items Stats )
        private bool toolTipOn;

        private Canvas canvas;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            canvas = GetComponentInParent<Canvas>();
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

            toolTipOn = true;
            gameObject.SetActive(true);
        }

        private void LateUpdate()
        {
            if (!toolTipOn) return;
            offset.y = toolTipRect.sizeDelta.y;

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
            toolTipRect.transform.position = canvas.transform.TransformPoint(pos + offset);
        }

        public void HideToolTip()
        {
            gameObject.SetActive(false);
            toolTipOn = false;
        }
    }
}