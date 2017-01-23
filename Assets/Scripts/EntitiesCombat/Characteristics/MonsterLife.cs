using UnityEngine;
using System.Collections;


namespace Monster
{
    [RequireComponent(typeof(Monster))]

    public class MonsterLife : Life
    {
        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            lifeEntity = this.GetComponent <Monster> ();
        }

    }
}

