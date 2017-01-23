using UnityEngine;
using System.Collections;
using GameInput;

public class StartCombatTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider entity)
    {
        if(entity.tag == "Player")
        {
            //startCombat
            ContextManager.instance.ChangeContext(InputContextList.Combat);

            CombatManager.instance.currentCombatZone = this.transform.parent.gameObject.GetComponent<CombatZone>();
            Destroy(this.gameObject);
            //Hide();
            //Invoke("DestroyTrigger", 0.5f);
        }
    }

    /*void Hide()
    {
        this.gameObject.SetActive(false);
    }

    void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }*/
}
