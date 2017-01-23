using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableClassAsset : MonoBehaviour {

    [MenuItem("Assets/Create/CustomActionList")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<CustomActionList>();
    }
}
