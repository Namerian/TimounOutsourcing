using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomActionList))]
public class CustomActionListEditor : Editor
{

    enum displayFieldType { DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields }
    displayFieldType DisplayFieldType;

    CustomActionList t;
    CustomActionList actionList;
    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int ListSize;

    void OnEnable()
    {
        /*if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            actionList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CustomActionList)) as CustomActionList;
        }*/

        t = (CustomActionList)target;
        GetTarget = new SerializedObject(t);
        ThisList = GetTarget.FindProperty("listOfActions"); // Find the List in our script and create a refrence of it
    }

    public override void OnInspectorGUI()
    {
        //Update our list

        GetTarget.Update();

        //Choose how to display the list<> Example purposes only
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        DisplayFieldType = (displayFieldType)EditorGUILayout.EnumPopup("", DisplayFieldType);

        //Resize our list
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        /*if (GUILayout.Button("Create Scriptable Object"))
        {
            t = ScriptableObject.CreateInstance<CustomActionList>();

            AssetDatabase.CreateAsset(t, "Assets/TestActionList.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Selection.activeObject = t;
        }*/
        

        //EditorGUILayout.LabelField("Define the list size with a number");
        ListSize = ThisList.arraySize;
        //ListSize = EditorGUILayout.IntField("List Size", ListSize);

        if (ListSize != ThisList.arraySize)
        {
            while (ListSize > ThisList.arraySize)
            {
                ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
            }
            while (ListSize < ThisList.arraySize)
            {
                ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
            }
        }

        if (GUILayout.Button("Add New Action"))
        {
            t.listOfActions.Add(new CustomActionList.Action());
            
        }
        //Display our list to the inspector window

        for (int i = 0; i < ThisList.arraySize; i++)
        {
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);

            SerializedProperty name = MyListRef.FindPropertyRelative("name");
            SerializedProperty owner = MyListRef.FindPropertyRelative("owner");
            SerializedProperty ranged = MyListRef.FindPropertyRelative("ranged");
            SerializedProperty isCasting = MyListRef.FindPropertyRelative("isCasting");
            SerializedProperty damage = MyListRef.FindPropertyRelative("damage");
            SerializedProperty damageMultiplier = MyListRef.FindPropertyRelative("damageMultiplier");
            SerializedProperty stamina = MyListRef.FindPropertyRelative("stamina");
            SerializedProperty armorPiercingBonus = MyListRef.FindPropertyRelative("armorPiercingBonus");
            SerializedProperty GuardBreaker = MyListRef.FindPropertyRelative("GuardBreaker");
            SerializedProperty maxTime = MyListRef.FindPropertyRelative("maxTime");
            SerializedProperty goodPercent = MyListRef.FindPropertyRelative("goodPercent");
            SerializedProperty goodPercentStart = MyListRef.FindPropertyRelative("goodPercentStart");
            SerializedProperty perfectPercent = MyListRef.FindPropertyRelative("perfectPercent");
            SerializedProperty perfectPercentStart = MyListRef.FindPropertyRelative("perfectPercentStart");

            EditorGUILayout.PropertyField(name);
            EditorGUILayout.PropertyField(owner);
            EditorGUILayout.PropertyField(ranged);
            EditorGUILayout.PropertyField(isCasting);
            EditorGUILayout.PropertyField(damage);
            EditorGUILayout.PropertyField(damageMultiplier);
            EditorGUILayout.PropertyField(stamina);
            EditorGUILayout.PropertyField(armorPiercingBonus);
            EditorGUILayout.PropertyField(GuardBreaker);
            EditorGUILayout.PropertyField(maxTime);
            EditorGUILayout.PropertyField(goodPercent);
            EditorGUILayout.PropertyField(goodPercentStart);
            EditorGUILayout.PropertyField(perfectPercent);
            EditorGUILayout.PropertyField(perfectPercentStart);

            EditorGUILayout.Space();

            //Remove this index from the List
            EditorGUILayout.LabelField("Remove an index from the List<> with a button");
            if (GUILayout.Button("Remove This Action Index (" + i.ToString() + ")"))
            {
                ThisList.DeleteArrayElementAtIndex(i);
            }
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        //Apply the changes to our list
        GetTarget.ApplyModifiedProperties();
    }
}
