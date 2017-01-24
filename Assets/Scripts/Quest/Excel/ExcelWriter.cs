using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
//using UnityEditor;

public class ExcelWriter : MonoBehaviour {

    private List<string[]> rowData = new List<string[]>();
    private string name;


    // Use this for initialization
    void Start()
    {
        Save();
    }

    void Save()
    {
        name = "Bob";
        AddLine("ID", "Text Start", "Text Completing", "Text End");
        //AddLine("1", "Salut l'ami !");
        //AddLine("2", "J'ai une misson pour toi");
        //AddLine("4", "Va chercher ton Bobibnette");

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        using (StreamWriter outStream = File.CreateText(filePath))
        {
            outStream.WriteLine(sb);
            outStream.Close();
        }

        using (StreamReader sr = File.OpenText(filePath))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Debug.Log(s);
            }
        }
        //AssetDatabase.Refresh();
    }

    public void AddLine(string ID, string textStart, string textCompleting, string textEnd)
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[4];
        rowDataTemp[0] = ID;
        rowDataTemp[1] = textStart;
        rowDataTemp[2] = textCompleting;
        rowDataTemp[3] = textEnd;
        rowData.Add(rowDataTemp);
    }

    
    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
//#if UNITY_EDITOR
       return Application.dataPath + "/Resources/" + name+".csv";/*
#elif UNITY_ANDROID
                return Application.persistentDataPath+ "/CSV/" + name+".csv";
#elif UNITY_IPHONE
                return Application.persistentDataPath+ "/CSV/" + name+".csv";
#else
                return Application.dataPath + "/CSV/" + name+".csv";
#endif*/
    }
}
