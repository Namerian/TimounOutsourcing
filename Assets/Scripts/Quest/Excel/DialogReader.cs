using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogReader : MonoBehaviour
{
    public static DialogReader instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public List<string> listOfText;
    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

    // Use this for initialization
    void Start()
    {

        //listOfText.Add(GetData("Bob",4, "Text Start"));
    }

    public string GetData(string name,int id, string text)
    {
        data = CSVReader.Read(name);
        
        for(int i = 0; i < data.Count; i++)
        {
            int tempId = System.Int32.Parse(data[i]["ID"].ToString());
            if(tempId == id)
            {
                if(data[i][text].ToString() != "")
                {
                    return data[i][text].ToString();
                }
               
            }
        }
        return "";
    }
}
