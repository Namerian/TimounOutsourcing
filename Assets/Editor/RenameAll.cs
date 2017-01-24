using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class RenameAll
{


    [MenuItem("Tools/RenameAll")]
    private static void RenameAllPrefabs()
    {

        if (Selection.activeObject != null)
        {
            MultiplyPannel();
        }

    }


    static void MultiplyPannel()
    {

        RenameWindow.ShowPopUp();

    }

    public class RenameWindow : EditorWindow
    {
        public static RenameWindow window = null;

        public static string newName = "";

        public static void ShowPopUp()
        {
            if (window != null)
            {
                window.Close();
            }
            window = ScriptableObject.CreateInstance<RenameWindow>();
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 100);
            window.ShowPopup();

        }

        void OnGUI()
        {

            EditorGUILayout.LabelField("Rename all selected objects", EditorStyles.wordWrappedLabel);
            GUILayout.Space(10);

            newName = EditorGUILayout.TextField("New name", newName);

            if (GUILayout.Button("Validate"))
            {
                foreach (Object _object in Selection.objects)
                {
                    _object.name = newName;
                }

                Close();
            }

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }

        }

    }
}

