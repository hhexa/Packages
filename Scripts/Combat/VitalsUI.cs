﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Kira.Combat
{
    public class VitalsUI : MonoBehaviour
    {
        [SerializeField]
        private Transform healthPanel;

        [SerializeField]
        private Image healthImage;

        private Vitals vitals;

        private void OnEnable()
        {
            if (vitals != null)
            {
                vitals.OnHitEvent += RefreshUI;
            }
        }

        private void OnDisable()
        {
            if (vitals != null)
            {
                vitals.OnHitEvent -= RefreshUI;
            }
        }

        private void OnValidate()
        {

            if (vitals == null)
            {
                vitals = GetComponent<Vitals>();
            }

            if (healthImage == null && healthPanel != null)
            {
                healthImage = healthPanel.GetChild(0).GetComponent<Image>();
            }
        }

        public void RefreshUI()
        {
            float fill = vitals.Health / vitals.MaxHealth;
            healthImage.fillAmount = fill;
        }
    }
}