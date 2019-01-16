using System;
using UnityEngine;

namespace Kira.Combat
{
    public class Attackable : Vitals
    {
        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}