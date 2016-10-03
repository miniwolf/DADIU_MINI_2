using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnObjectsLevelDesignTool : MonoBehaviour {
	string[][] organizedSplitData;
	List<GameObject>[] theStates = new List<GameObject>[10];
	GameObject[] allChildren;
	public int stateToShow = 6;

	private TextAsset txtFile;

	public bool randomStateSelection = false;

	void Awake() {
		if (randomStateSelection) {
			stateToShow = Random.Range(0, 10);
		}
		allChildren = GameObject.FindGameObjectsWithTag("LaundryFormation");
		txtFile = (TextAsset)Resources.Load("LevelDesignSave", typeof(TextAsset));
		InitStates();
		ReadText();
	}

	// Use this for initialization
	void Start() {
		HideAllGO();
		for (int i = 0; i < theStates[stateToShow].Count; i++) {
			theStates[stateToShow][i].SetActive(true);
		}
	}

	void HideAllGO() {
		for (int i=0;i<allChildren.Length;i++) {
			allChildren[i].SetActive(false);
		}

	}

	void InitStates() {
		for (int i = 0; i < theStates.Length; i++) {
			theStates[i] = new List<GameObject>();
		}
	}

	void ReadText() {
		//string allData = System.IO.File.ReadAllText("Assets/Resources/LevelDesignSave.txt");
		string allData = txtFile.text;

		string[] splitData = allData.Split(':');
		organizedSplitData = new string[splitData.Length][];
		for (int i = 0; i < splitData.Length; i++) {
			string[] temp = splitData[i].Split(',');
			organizedSplitData[i] = new string[temp.Length];
			if (temp.Length > 0) {
				for (int u = 0; u < temp.Length; u++) {
					organizedSplitData[i][u]=temp[u];
				}
			}
		}
		FindObjects();
	}

	void FindObjects() {
		for (int i = 0; i < organizedSplitData.Length; i++) {
			if (organizedSplitData[i].Length > 0) {
				for (int u = 0; u < organizedSplitData[i].Length; u++) {
					for (int k = 0; k < allChildren.Length; k++) {
						if (organizedSplitData[i][u].Equals(allChildren[k].name)) {
							theStates[i].Add(allChildren[k].gameObject);
						}
					}
				}
			}
		}
	}
}
