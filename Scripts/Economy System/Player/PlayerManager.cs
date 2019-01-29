using System;
using UnityEngine;

namespace Kira.Economy
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Player { get; private set; }
        public PlayerTrader Trader { get; private set; }
        public PlayerUI UI { get; private set; }

        void Awake()
        {
            if (Player == null)
            {
                Player = this;
            }
            else
            {
                Destroy(gameObject);
            }

            Trader = GetComponent<PlayerTrader>();
            UI = GetComponent<PlayerUI>();

            UI.playerTrader = Trader;
        }

        void Update()
        {

        }
    }
}