using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class Replace : EditorWindow
{

    public List<string> m_Identifier = new List<string>();

    public static GameObject m_Old= null;

    public static GameObject m_New = null;

    public static string oldName = "";

    [MenuItem("Tools/ReplaceTool")]
    public static void ShowWindow( )
    {
        oldName = "";

        m_Old = null;

        m_New = null;
        EditorWindow.GetWindow(typeof(Replace));
    }

    void OnGUI( )
    {

        EditorGUILayout.BeginVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Old object");
        m_Old = (GameObject) EditorGUILayout.ObjectField(m_Old, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        oldName = EditorGUILayout.TextField("Old Name(s)", oldName);
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("New object");
        m_New = (GameObject)EditorGUILayout.ObjectField(m_New, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginHorizontal();


        if (m_New != null)
        {
            if (m_Old != null && oldName == "")
            {

                if (GUILayout.Button("Replace"))
                {
                    ReplaceOne();
                    this.Close();
                }

            }

            if (oldName != "" && m_Old == null)
            {

                if (GUILayout.Button("Replace All"))
                {
                    AskForValidation();

                }
            }

        }
        EditorGUILayout.EndHorizontal();

    }

  
    public void ReplaceOne()
    {
        if (m_New == null || m_Old ==null)
        {
            Debug.LogError("Fill all the paramter");
            return;
        }


        GameObject _go = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/" + m_New.name + ".prefab", typeof(GameObject)));

        GameObject Instance;
        Instance = PrefabUtility.InstantiatePrefab(_go) as GameObject;

        if (m_Old.transform.parent != null)
        {
            Instance.transform.parent = m_Old.transform.parent;
        }

        Instance.transform.localPosition = m_Old.transform.localPosition;
        Instance.transform.localRotation = m_Old.transform.localRotation;
        Instance.transform.localScale = m_Old.transform.localScale;

        DestroyImmediate(m_Old);

        Debug.Log("END");
    }

    public void AskForValidation()
    {
        ReplaceValidation.ShowPopUp( m_New, oldName);
    }

}


public class ReplaceValidation : EditorWindow
{
    public static int numberOfObjects=0;

    public static GameObject m_New = null;

    public static string oldName = "";

    public static void ShowPopUp(GameObject _new, string _oldName)
    {

        m_New = _new;

        oldName = _oldName;

        GameObject[] AllGameObject = FindObjectsOfType<GameObject>();

        List<GameObject> GameObjectToChange = new List<GameObject>();

        foreach (GameObject _GameObject in AllGameObject)
        {
            if (_GameObject.gameObject.name == oldName)
            {
                GameObjectToChange.Add(_GameObject);
            }
        }

        numberOfObjects = GameObjectToChange.Count;

        ReplaceValidation window = ScriptableObject.CreateInstance<ReplaceValidation>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("You are gonna modify "+ numberOfObjects +" objects", EditorStyles.wordWrappedLabel);
        EditorGUILayout.LabelField("Are you sure ?", EditorStyles.wordWrappedLabel);
        GUILayout.Space(50);
        if (GUILayout.Button("Agree!"))
        {
            ReplaceAll();
            this.Close();
        }

        if (GUILayout.Button("No"))
        {
            this.Close();
        }

    }

    public void ReplaceAll()
    {
      

        GameObject[] AllGameObject = FindObjectsOfType<GameObject>();

        List<GameObject> GameObjectToChange = new List<GameObject>();

        foreach (GameObject _GameObject in AllGameObject)
        {
            if (_GameObject.gameObject.name == oldName)
            {
                GameObjectToChange.Add(_GameObject);
            }
        }

        if (GameObjectToChange.Count == 0)
        {
            Debug.LogError("No Gameobject found");
            return;
        }

        GameObject _go = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/" + m_New.name + ".prefab", typeof(GameObject)));

        for (int i = 0; i < GameObjectToChange.Count; i++)
        {
            GameObject Instance;
            Instance = PrefabUtility.InstantiatePrefab(_go) as GameObject;

            if (GameObjectToChange[i].transform.parent != null)
            {
                Instance.transform.parent = GameObjectToChange[i].transform.parent;
            }

            Instance.transform.localPosition = GameObjectToChange[i].transform.localPosition;
            Instance.transform.localRotation = GameObjectToChange[i].transform.localRotation;
            Instance.transform.localScale = GameObjectToChange[i].transform.localScale;


            DestroyImmediate(GameObjectToChange[i]);
        }

        Debug.Log("END");

    }

}