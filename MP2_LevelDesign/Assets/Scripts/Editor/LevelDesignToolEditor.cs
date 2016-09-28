using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LevelDesignTool))]
public class LevelDesignToolEditor : Editor {
	public int stateToSave;
	public int stateToShow;

	public override void OnInspectorGUI () {
		LevelDesignTool ldt = (LevelDesignTool)target;

		bool allowSceneObjects = !EditorUtility.IsPersistent(target);

		ldt.parentOfLaundryFormation = (GameObject)EditorGUILayout.ObjectField("Parent for laundry formation", ldt.parentOfLaundryFormation, typeof(GameObject), allowSceneObjects);

		stateToSave = EditorGUILayout.IntField("State to save in", stateToSave);

		if (GUILayout.Button("Save in specified state")) {
			ldt.SaveActiveObjects(stateToSave);
		}
			
		stateToShow = EditorGUILayout.IntField("Show this state", stateToShow);
		if (GUILayout.Button("Show the specified state")) {
			ldt.ShowState(stateToShow);
		}

		if (GUILayout.Button("Hide All")) {
			ldt.HideAll();
		}
		if (GUILayout.Button("Show all")) {
			ldt.ShowAll();
		}
		if (GUILayout.Button("Load All")) {
			ldt.LoadAllStates();
		}
			
		EditorUtility.SetDirty(target);
	}
}
