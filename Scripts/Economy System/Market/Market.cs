using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kira.Economy
{
    public class Market : MonoBehaviour
    {
        private IDictionary<Commodity, Order> orders = new Dictionary<Commodity, Order>();
        public IDictionary<Commodity, Order> Orders { get => orders; private set => orders = value; }

        //Receive Orders from Traders

        //If a buy order is received then look for sell orders that match with 
        //a price less then or equal to the buy orders price

        //If a sell order is received then look at buy orders of the same commoditiy.
        //Find an order which has a price equal to or greater then the asking price of the sell order

        //IDictionary of Orders and Commodities as ID's !?       

    }
}