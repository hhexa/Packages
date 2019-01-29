using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kira.Prototype
{

    public class Character : MonoBehaviour, IDamagable
    {
        protected float health;
        [SerializeField] protected float maxHealth = 100;

        private void Awake()
        {
            health = maxHealth;
        }


        public virtual void TakeDamage(float damage)
        {
            health -= damage;

            if (health < 0)
            {
                health = 0;
            }
        }

    }

}