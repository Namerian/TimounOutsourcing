using UnityEngine;
using System.Collections;
using System;
using GameInput;
public class TriggerCombat : Trigger
{
    protected override void Execute()
    {
        //startCombat
        CombatManager.instance.currentCombatZone = this.transform.parent.gameObject.GetComponent<CombatZone>();
        ContextManager.instance.ChangeContext(InputContextList.Combat);
        Destroy(this.gameObject);
    }

    void Start()
    {
        triggerType = TriggerType.Combat;
        TriggerManager.instance.triggerList.Add(this);
    }

    protected override void OnDestroy()
    {
        TriggerManager.instance.RemoveFromList(this);
    }
}
