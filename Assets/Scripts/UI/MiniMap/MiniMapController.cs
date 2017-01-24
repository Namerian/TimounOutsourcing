using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class MapObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class MiniMapController : MonoBehaviour {
    public Camera mapCamera;

    public List<MapObject> mapObjects = new List<MapObject>();

    private static MiniMapController miniMapController;

    public static MiniMapController Instance()
    {
        if (!miniMapController)
        {
            miniMapController = FindObjectOfType(typeof(MiniMapController)) as MiniMapController;
            if (!miniMapController)
                Debug.LogError("There needs to be one active MiniMapController script on a GameObject in your scene.");
        }

        return miniMapController;
    }

    public void RegisterMapObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        mapObjects.Add(new MapObject() { owner = o, icon = image });
    }

    public void RemoveMapObject(GameObject o)
    {
        List<MapObject> newList = new List<MapObject>();
        for(int i =0; i < mapObjects.Count; i++)
        {
            if(mapObjects[i].owner == o)
            {
                Destroy(mapObjects[i].icon);
                mapObjects.Remove(mapObjects[i]);
                continue;
            }
            else
            {
                newList.Add(mapObjects[i]);
            }
            //mapObjects.RemoveRange(0, mapObjects.Count);
            //mapObjects.AddRange(newList);
        }
    }

    void DrawMapIcons()
    {
        foreach(MapObject mo in mapObjects)
        {

            //Code to enable/disable clamped icon
            /*Vector2 mop = new Vector2(mo.owner.transform.position.x, mo.owner.transform.position.y);
            Vector2 pp = new Vector2(playerPos.position.x, playerPos.position.y);

            if(Vector2.Distance(mop, pp) > 100)
            {
                mo.icon.enabled = false;
                continue;
            }else
            {
                mo.icon.enabled = true;
            }*/
            Vector3 screenPos = mapCamera.WorldToViewportPoint(mo.owner.transform.position);
            mo.icon.transform.SetParent(this.transform);
            mo.icon.preserveAspect = true;
            RectTransform rt = this.GetComponent<RectTransform>();
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);

            screenPos.x = screenPos.x * rt.rect.width + corners[0].x;
            screenPos.y = screenPos.y * rt.rect.height + corners[0].y;
            screenPos.z = 0;
            mo.icon.GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);

            mo.icon.transform.position = screenPos;
            
            if(mo.owner.GetComponent<CharacterControllerLogic>())
            {
                mo.icon.transform.rotation = Quaternion.Euler(0, 0, -mo.owner.GetComponent<CharacterControllerLogic>().transform.localEulerAngles.y + Camera.main.transform.eulerAngles.y);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        DrawMapIcons();
	}
}
