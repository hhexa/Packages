using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kira.Economy
{
    [RequireComponent(typeof(PlayerTrader))]
    public class PlayerUI : MonoBehaviour
    {
        public PlayerTrader playerTrader { get; set; }

        private float cash;

        [SerializeField]
        private TextMeshProUGUI cashText;

        private void Start()
        {
            playerTrader.OnCashChangedEvent += RefreshUI;
            RefreshUI();
        }

        public void RefreshUI()
        {
            cash = playerTrader.Cash;
            cashText.text = String.Format("Cash {0}$", cash);
        }
    }
}