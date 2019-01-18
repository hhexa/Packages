using UnityEngine;
using Kira.Combat;

namespace Kira.Characters
{
    [RequireComponent(typeof(Vitals))]
    public class Npc : CharacterBase
    {
        protected Vitals vitals;

        protected virtual void Awake()
        {
            vitals = GetComponent<Vitals>();
            vitals.OnKilledEvent += OnDie;
            vitals.OnHitEvent += OnHit;
        }

        public virtual void OnHit()
        {

        }

        public virtual void OnDie()
        {

        }

        public Vitals Vitals
        {
            get { return vitals; }
            protected set { vitals = value; }
        }
    }
}