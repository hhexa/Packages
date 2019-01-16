
using System;
using UnityEngine;

namespace Kira.Combat
{
    public class Vitals : MonoBehaviour
    {
        [SerializeField] protected float health = 100;
        [SerializeField] protected float maxHealth = 100;

        public event Action OnHitEvent;
        public event Action OnKilledEvent;

        public float Health
        {
            get { return health; }
            protected set { health = value; }
        }

        public float MaxHealth
        {
            get { return maxHealth; }
            protected set { maxHealth = value; }
        }

        public virtual void TakeDamage(float damage)
        {
            if (OnHitEvent != null)
            {
                OnHitEvent();
            }

            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        /*
        <summary>
            reduces health by a percent instead of a flat amount
        </summary>
         */

        public virtual void TakeDamagePercent(float amount)
        {
            health -= health * (amount / 100);

            if (OnHitEvent != null)
            {
                OnHitEvent();
            }
        }

        protected virtual void Die()
        {
            health = 0;

            //Call Event before destroying object
            if (OnKilledEvent != null)
                OnKilledEvent();

            Destroy(gameObject);
        }
    }
}