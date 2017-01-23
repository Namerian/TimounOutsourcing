using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class CloneToolEditor : EditorWindow
{
	[System.Serializable]
	public class Count
	{
		public int x = 1;
		public int y = 1;
		public int z = 1;
		public int oldX = 1;
		public int oldY = 1;
		public int oldZ = 1;
	}
	
	private bool				useLocal			= true;
	private bool				oldUseLocal			= true;

	private Vector3				offset				= Vector3.zero;
	private Vector3				oldOffset			= Vector3.zero;

	private Count				count				= new Count();

	private Vector3				oldPosition			= Vector3.zero;
	private Vector3				oldScale			= Vector3.zero;
	private Quaternion			oldRotation			= Quaternion.identity;

	private List<GameObject>	clones				= new List<GameObject>();
	private GameObject			clonedGameObject	= null;

	[MenuItem("Tools/Clone Tool", false, 0)]
	private static void OpenWindow()
	{
		var cloneTool = GetWindow(typeof(CloneToolEditor)) as CloneToolEditor;
		cloneTool.minSize = new Vector2(280f, 100f);
		cloneTool.titleContent.text = "Clone Tool";
	}

	private void OnEnable()
	{
		string prefsOffset = EditorPrefs.GetString("CloneToolEditoroffset", JsonUtility.ToJson(offset));
		offset = JsonUtility.FromJson<Vector3>(prefsOffset);
		count = GetCount();
	}

	private Count GetCount()
	{
		string prefsCount = EditorPrefs.GetString("CloneToolEditorcount", JsonUtility.ToJson(count));
		return JsonUtility.FromJson<Count>(prefsCount);
	}

	private void OnDisable()
	{
		EditorPrefs.SetString("CloneToolEditoroffset", JsonUtility.ToJson(offset));
		EditorPrefs.SetString("CloneToolEditorcount", JsonUtility.ToJson(count));
		Clear();
	}

	private void OnLostFocus()
	{
		Clear();
	}

	private void Update()
	{
		if(Selection.activeGameObject != clonedGameObject)
		{
			clonedGameObject = Selection.activeGameObject;
			//if(clonedGameObject == null || clones.Contains(clonedGameObject))
			//{
				Clear();
			//}
		}
		else if(count.oldX != count.x 
		|| count.oldY != count.y 
		|| count.oldZ != count.z 
		|| oldOffset != offset)
		{
			count.oldX = count.x;
			count.oldY = count.y;
			count.oldZ = count.z;
			oldOffset = offset;
		}
		else if(CheckOldTransformChangesAndRefresh())
		{

		}
		else if(Selection.objects.Length != 1)
		{
			Selection.activeObject = null;
			clonedGameObject = null;
			Clear();
		}
		else if(clones.Count != count.x * count.y * count.z)
		{

		}
		else if(oldUseLocal != useLocal)
		{
			oldUseLocal = useLocal;
		}
		else
		{
			return;
		}
		RefreshClones();
	}

	private bool CheckOldTransformChangesAndRefresh()
	{
		if(clonedGameObject == null)
		{
			return false;
		}
		Transform tr = clonedGameObject.transform;
		if((tr.position != oldPosition)
		|| (tr.localScale != oldScale)
		|| (tr.rotation != oldRotation))
		{
			oldPosition = tr.position;
			oldScale = tr.localScale;
			oldRotation = tr.rotation;
			return true;
		}
		return false;
	}

	private void OnGUI()
	{
		DrawParameters();
		DrawOffsetAndCount();
		ApplyButton();
		Repaint();
	}

	private void DrawParameters()
	{
		EditorGUILayout.LabelField("Parameters", EditorStyles.boldLabel);
		useLocal = EditorGUILayout.Toggle("Use locals", useLocal);
		EditorGUILayout.Space();
	}

	private void DrawOffsetAndCount()
	{
		EditorGUI.BeginDisabledGroup(count.x == 1);
		offset.x = EditorGUILayout.FloatField("X", offset.x);
		EditorGUI.EndDisabledGroup();
		count.x = EditorGUILayout.IntSlider(count.x, 1, 100);

		EditorGUILayout.Separator();

		EditorGUI.BeginDisabledGroup(count.y == 1);
		offset.y = EditorGUILayout.FloatField("Y", offset.y);
		EditorGUI.EndDisabledGroup();
		count.y = EditorGUILayout.IntSlider(count.y, 1, 100);

		EditorGUILayout.Separator();

		EditorGUI.BeginDisabledGroup(count.z == 1);
		offset.z = EditorGUILayout.FloatField("Z", offset.z);
		EditorGUI.EndDisabledGroup();
		count.z = EditorGUILayout.IntSlider(count.z, 1, 100);
	}

	private void ApplyButton()
	{
		bool empty = clonedGameObject == null;
		EditorGUI.BeginDisabledGroup(empty);
		if(GUILayout.Button("Apply"))
		{
			Selection.activeObject = null;
			clonedGameObject = null;
			clones.Clear();
		}
		EditorGUI.EndDisabledGroup();
	}

	private void RefreshClones()
	{
		if(clonedGameObject == null)
		{
			return;
		}

		Transform	transform		= clonedGameObject.transform;
		int			targetCount		= count.x * count.y * count.z;
		int			cloneCount		= clones.Count;

		for(int cloneIndex = cloneCount - 1; cloneIndex >= targetCount; --cloneIndex)
		{
			DestroyImmediate(clones[cloneIndex]);
			clones.RemoveAt(cloneIndex);
		}
		for(int cloneIndex = cloneCount; cloneIndex < targetCount; ++cloneIndex)
		{
			if(cloneIndex != 0)
			{
				GameObject go = Instantiate(clonedGameObject) as GameObject;
				go.transform.SetParent(transform.parent, false);
				clones.Add(go);
			}
			else
			{
				clones.Add(null);
			}
		}

		Vector3 xLocalPosition	= transform.InverseTransformDirection(transform.right) * offset.x;
		Vector3 yLocalPosition	= transform.InverseTransformDirection(transform.up) * offset.y;
		Vector3 zLocalPosition	= transform.InverseTransformDirection(transform.forward) * offset.z;

		int		currentClone	= 0;
		bool	first			= true;

		for(int z = 0; z < count.z; ++z)
		for(int y = 0; y < count.y; ++y)
		for(int x = 0; x < count.x; ++x)
		{
			if(first)
			{
				first = false;
				currentClone++;
				continue;
			}

			Vector3	newPosition	= Vector3.zero;
			if(useLocal)
			{
				Vector3 xLocal = xLocalPosition * x;
				Vector3 yLocal = yLocalPosition * y;
				Vector3 zLocal = zLocalPosition * z;
				newPosition = transform.TransformPoint(xLocal + yLocal + zLocal);
			}
			else
			{
				float newX = transform.position.x + (x * offset.x);
				float newY = transform.position.y + (y * offset.y);
				float newZ = transform.position.z + (z * offset.z);
				newPosition = new Vector3(newX, newY, newZ);
			}

			RefreshClone(currentClone, transform, newPosition);
			currentClone++;
		}
	}

	private void RefreshClone(int currentClone, Transform transform, Vector3 newPosition)
	{
		clones[currentClone].transform.position = newPosition;
		clones[currentClone].transform.rotation = transform.rotation;
		transform.gameObject.SetActive(false);
		transform.gameObject.SetActive(true);
	}

	private void Clear()
	{
		for(int index = clones.Count - 1; index >= 0; --index)
		{
			DestroyImmediate(clones[index]);
		}
		clones.Clear();
	}
}