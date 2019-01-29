using System;
using UnityEngine;

namespace Kira.Economy
{
    public class PlayerTrader : Trader
    {
        // RayCast Vaiables
        Ray ray;
        float maxDistance = 500;
        [SerializeField] Color rayColor = Color.green;

        //Targeting Item Variables
        enum TargetState { No_Target, Has_Target };
        TargetState targetState;

        IInteractable target;

        public event Action OnCashChangedEvent;

        public bool Buy(Commodity item, float price)
        {
            if (cash >= price)
            {
                commodities.Add(item);
                cash -= price;

                if (OnCashChangedEvent != null)
                    OnCashChangedEvent();

                return true;
            }
            return false;
        }

        void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasTarget = Physics.Raycast(ray, out RaycastHit hit, 500);

            if (hasTarget)
            {
                IInteractable rayTarget = hit.transform.GetComponent<IInteractable>();

                //Highlights Item Hovering on
                if (rayTarget != null)
                {
                    target = rayTarget;
                    targetState = TargetState.Has_Target;
                    target.Highlight(true);
                }
                else if (targetState == TargetState.Has_Target)
                {
                    target.Highlight(false);
                    targetState = TargetState.No_Target;
                }

                if (Input.GetMouseButtonDown(1) && targetState == TargetState.Has_Target)
                {
                    rayTarget.Click();
                }
            }
        }
    }
}
