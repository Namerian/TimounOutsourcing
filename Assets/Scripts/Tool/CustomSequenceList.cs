using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class CustomSequenceList : MonoBehaviour {

    public static CustomSequenceList instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public enum Owner
    {
        Tank,
        Harasser,
        Monster,
    }

    [System.Serializable]
    public class Sequence
    {
        public string currentActionName;
        public int indexPopUp;
        public Owner owner;
        public List<string> listOfName;
    }

    [System.Serializable]
    public class ListSequences
    {
        public string name;
        public List<Sequence> sequences;
        public ListSequences()
        {
            sequences = new List<Sequence>(1);
            sequences.Add(new Sequence());
        }
        
    }
    
    
    public List<ListSequences> listOfSequences = new List<ListSequences>(1);

    public void SetCurrentNameAction(int indexParent, int indexSequence, int index)
    {

        if (indexParent < listOfSequences.Count && indexSequence < listOfSequences[indexParent].sequences.Count)
        {
            if (listOfSequences[indexParent].sequences[indexSequence].listOfName.Count > 0 && index < listOfSequences[indexParent].sequences[indexSequence].listOfName.Count)
            {
                listOfSequences[indexParent].sequences[indexSequence].currentActionName = listOfSequences[indexParent].sequences[indexSequence].listOfName[index];
            }
            
        }
        
    }

    public string[] SelectActionName(int indexParent, int index, int owner)
    {
        string[] options;

        if (listOfSequences[indexParent].sequences[index].listOfName != null)
        {
            listOfSequences[indexParent].sequences[index].listOfName.Clear();
        }else
        {
            listOfSequences[indexParent].sequences[index].listOfName = new List<string>();
        }

        if (owner == (int)Owner.Tank)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Tank.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach (CustomActionList.Action action in actionList.listOfActions)
            {
                
                listOfSequences[indexParent].sequences[index].listOfName.Add(action.name);
            }

            options = new string[listOfSequences[indexParent].sequences[index].listOfName.Count];
            for (int j = 0; j < options.Length; j++)
            {
                options[j] = listOfSequences[indexParent].sequences[index].listOfName[j];
            }
            return options;
        }else if (owner == (int)Owner.Harasser)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Harasser.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach (CustomActionList.Action action in actionList.listOfActions)
            {

                listOfSequences[indexParent].sequences[index].listOfName.Add(action.name);
            }

            options = new string[listOfSequences[indexParent].sequences[index].listOfName.Count];
            for (int j = 0; j < options.Length; j++)
            {
                options[j] = listOfSequences[indexParent].sequences[index].listOfName[j];
            }
            return options;
        }
        else if (owner == (int)Owner.Monster)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Monster.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach (CustomActionList.Action action in actionList.listOfActions)
            {

                listOfSequences[indexParent].sequences[index].listOfName.Add(action.name);
            }

            options = new string[listOfSequences[indexParent].sequences[index].listOfName.Count];
            for (int j = 0; j < options.Length; j++)
            {
                options[j] = listOfSequences[indexParent].sequences[index].listOfName[j];
            }
            return options;
        }

        return new string[0];
    }

    public CustomActionList.Action SelectAction(Owner owner, string actionName)
    {
        if(owner == Owner.Tank)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Tank.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach(CustomActionList.Action action in actionList.listOfActions)
            {
                if(action.name == actionName)
                {
                    return action;
                }
            }
        }
        else if (owner == Owner.Harasser)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Harasser.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach (CustomActionList.Action action in actionList.listOfActions)
            {
                if (action.name == actionName)
                {
                    return action;
                }
            }
        }
        else if (owner == Owner.Monster)
        {
#if UNITY_EDITOR
            CustomActionList actionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Monster.asset", typeof(CustomActionList)) as CustomActionList;
#endif
            foreach (CustomActionList.Action action in actionList.listOfActions)
            {
                if (action.name == actionName)
                {
                    return action;
                }
            }
        }

        return null;
    }
    
    void AddNew()
    {
        //Add a new index position to the end of our list
        listOfSequences.Add(new ListSequences());
    }

    void Remove(int index)
    {
        //Remove an index position from our list at a point in our list array
        listOfSequences.RemoveAt(index);
    }
}
