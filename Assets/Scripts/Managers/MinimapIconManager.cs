using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconManager : MonoBehaviour {

    public static MinimapIconManager instance;

    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        FillList();
    }

    public List<GameObject> listOfIcons = new List<GameObject>();
    public List<string> listOfIconsNames = new List<string>();

    void FillList()
    {
        Object[] allIcons = Resources.LoadAll("MinimapIcons/", typeof(GameObject));
        foreach (Object parObject in allIcons)
        {
            listOfIcons.Add((GameObject)parObject);
            listOfIconsNames.Add(parObject.name);
        }
    }

    public GameObject GetIcon(string parString)
    {
        GameObject Icon = listOfIcons.Find(x => x.name == parString);
        if (Icon == null)
        {
            Debug.Log("Prefabs/UI/Minimap/Resources/MinimapIcons " + parString + " does not exist !");
            return null;
        }
        else
        {
            return Icon;
        }

    }
}
