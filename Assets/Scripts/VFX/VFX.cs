using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class VFX : MonoBehaviour {

    /// <summary>
    /// Spawns a visual effect with the desired behavior
    /// </summary>
    /// <param name="vfx"> VFX to spawn</param>
    /// <param name="parentObj">Parent where to spawn the VFX</param>
    /// <param name="offset">Offset from initial parent position</param>
    /// <param name="lifeTime"> 0 = looping VFX, Other values will make sure the object gets destroyed</param>
    /// <returns></returns>
    public GameObject InstantiateVFX(GameObject vfx, GameObject parentObj, Vector3 offset = default(Vector3),float lifeTime=0)
    {
        GameObject spawnedVFX = Instantiate(vfx);
        spawnedVFX.transform.parent = parentObj.transform;

        spawnedVFX.transform.position = parentObj.transform.position + offset;

        VFXManager.instance.listOfVFX.Add(spawnedVFX);

        if (lifeTime > 0)
            DestroyVFX(spawnedVFX, lifeTime);

        return spawnedVFX;
    }

    /// <summary>
    /// Destroys a VFX
    /// </summary>
    /// <param name="vfx">VFX to destroy</param>
    /// <param name="t">Optional time before destruction</param>
    public void DestroyVFX(GameObject vfx,float t=0)
    {
        StartCoroutine(CoDestroyVFX(vfx, t));
    }

    private IEnumerator CoDestroyVFX(GameObject vfx, float t)
    {
        yield return new WaitForSeconds(t);
        if (VFXManager.instance.listOfVFX.Contains(vfx))
            VFXManager.instance.listOfVFX.Remove(vfx);
        else
            Debug.LogWarning("Not Referenced Fx just got destroyed");
        Destroy(vfx);
    }
}
