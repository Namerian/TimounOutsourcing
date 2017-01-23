using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomSequenceList))]
[System.Serializable]
public class CustomSequenceListEditor : Editor
{

    //enum displayFieldType { DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields }
    //displayFieldType DisplayFieldType;

    [SerializeField]
    CustomSequenceList t;
    [SerializeField]
    SerializedObject GetTarget;
    [SerializeField]
    SerializedProperty ThisSequence;
    [SerializeField]
    SerializedProperty ThisListSequences;
    [SerializeField]
    int ListSize;
    [SerializeField]
    int ListSizeSequences;
    [SerializeField]
    int[,] index = new int[50,50];
    //[SerializeField]
    //int[,] lastOwner = new int[50,50];
    

    void OnEnable()
    {
        Debug.Log(GetTarget);
        if (GetTarget == null)
        {
            t = (CustomSequenceList)target;
            GetTarget = new SerializedObject(t);
            ThisListSequences = GetTarget.FindProperty("listOfSequences");
            Debug.Log("start");
        }
       
    }

    public override void OnInspectorGUI()
    {
        //Update our list

        GetTarget.Update();

        //Choose how to display the list<> Example purposes only
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //DisplayFieldType = (displayFieldType)EditorGUILayout.EnumPopup("", DisplayFieldType);

        //Resize our list
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //EditorGUILayout.LabelField("Define the list size with a number");

        ListSize = ThisListSequences.arraySize;
        //ListSize = EditorGUILayout.IntField("List Size", ListSize);



        if (ListSize != ThisListSequences.arraySize)
        {
            while (ListSize > ThisListSequences.arraySize)
            {
                ThisListSequences.InsertArrayElementAtIndex(ThisListSequences.arraySize);
            }
            while (ListSize < ThisListSequences.arraySize)
            {
                ThisListSequences.DeleteArrayElementAtIndex(ThisListSequences.arraySize - 1);
            }
        }

        if (GUILayout.Button("Add New Sequence"))
        {
            t.listOfSequences.Add(new CustomSequenceList.ListSequences());
        }

        //index = new int[ThisListSequences.arraySize, ThisSequence.arraySize];
        //lastOwner = new int[ThisListSequences.arraySize, ThisSequence.arraySize];


        for (int k = 0; k < ThisListSequences.arraySize; k++)
        {
            SerializedProperty MyListRef = ThisListSequences.GetArrayElementAtIndex(k);
            SerializedProperty name = MyListRef.FindPropertyRelative("name");
            EditorGUILayout.PropertyField(name);

            ThisSequence = ThisListSequences.GetArrayElementAtIndex(k).FindPropertyRelative("sequences");// Find the List in our script and create a refrence of it

            ListSizeSequences = ThisSequence.arraySize;

            if (ListSizeSequences != ThisSequence.arraySize)
            {
                while (ListSizeSequences > ThisSequence.arraySize)
                {
                    ThisSequence.InsertArrayElementAtIndex(ThisSequence.arraySize);
                }
                while (ListSizeSequences < ThisSequence.arraySize)
                {
                    ThisSequence.DeleteArrayElementAtIndex(ThisSequence.arraySize - 1);
                }
            }

            if (GUILayout.Button("Add New Action", GUILayout.Width(100), GUILayout.MinWidth(100), GUILayout.MaxWidth(200)))
            {
                t.listOfSequences[k].sequences.Add(new CustomSequenceList.Sequence());
            }
            //Display our list to the inspector window
            for (int i = 0; i < ThisSequence.arraySize; i++)
            {
                GUILayout.BeginHorizontal();
                SerializedProperty MyListSequencesRef = ThisSequence.GetArrayElementAtIndex(i);
                SerializedProperty indexPopUp = MyListSequencesRef.FindPropertyRelative("indexPopUp");
                SerializedProperty owner = MyListSequencesRef.FindPropertyRelative("owner");
                SerializedProperty listOfName = MyListSequencesRef.FindPropertyRelative("listOfName");
                EditorGUILayout.PropertyField(owner);

                /*if (lastOwner[k,i] != owner.enumValueIndex)
                {
                    lastOwner[k,i] = owner.enumValueIndex;
                }*/
                indexPopUp.intValue = EditorGUILayout.Popup(indexPopUp.intValue, t.SelectActionName(k, i, owner.enumValueIndex), GUILayout.Width(100), GUILayout.MinWidth(100), GUILayout.MaxWidth(200));
                t.SetCurrentNameAction(k, i, indexPopUp.intValue);
                EditorGUILayout.Space();

                //Remove this index from the List
                //EditorGUILayout.LabelField("Remove an index from the List<> with a button");
                if (GUILayout.Button("Remove", GUILayout.Width(100), GUILayout.MinWidth(100), GUILayout.MaxWidth(200)))
                {
                    index[k, i] = 0;
                    //lastOwner[k, i] = 0;
                    ThisSequence.DeleteArrayElementAtIndex(i);
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                GUILayout.EndHorizontal();

            }

            EditorGUILayout.Space();

            //Remove this index from the List
            EditorGUILayout.LabelField("Remove an index from the List<> with a button");
            if (GUILayout.Button("Remove This Sequence Index (" + k.ToString() + ")"))
            {
                for (int i = 0; i < ThisSequence.arraySize; i++)
                {
                    index[k, i] = 0;
                    //lastOwner[k, i] = 0;
                }
                ThisListSequences.DeleteArrayElementAtIndex(k);
            }
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

        }


        GetTarget.ApplyModifiedProperties();
        //Apply the changes to our list
    }     
}
