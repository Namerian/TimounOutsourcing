using UnityEngine;
using System.Collections;
using Events;
using Combat;

namespace Monster
{
    [RequireComponent(typeof(Monster))]
    public class MonsterStamina : Stamina,
        CombatEvents.IInitCombatHandler
    {
        public bool canRegen;
        protected override void Awake()
        {
            base.Awake();
            _entityStamina = this.GetComponent<Monster>();
            EventCenter.AddSubscriber(this);
        }

        IEnumerator RegenStamina()
        {
            while (canRegen)
            {
                yield return new WaitForSeconds(staminaRegenerationDelay);
                AddStamina(staminaRegenerationRate);
            }
        }

        public void OnInitCombat()
        {
            canRegen = true;
            StartCoroutine(RegenStamina());
        }
    }
}


