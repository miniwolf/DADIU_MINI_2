﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelDesignTool : MonoBehaviour {
	public List<GameObject>[] theStates = new List<GameObject>[10];
	public GameObject parentOfLaundryFormation;
	public int stateToShowIn, stateToSaveIn;

	private bool statesInit = false;
	private string allData;
	private string[] splitData;
	private List<string>[] organizedSplitData;

	public void InittheStates() {
		for (int i = 0; i < theStates.Length; i++) {
			theStates[i] = new List<GameObject>();
		}
		statesInit = true;
	}

	private bool StatesInit() {
		for (int i = 0; i < theStates.Length; i++) {
			if (theStates[i] == null) {
				return false;
			}
		}
		return true;
	}

	public void SaveActiveObjects(int stateToSaveIn) {
		if (!StatesInit()) {
			InittheStates();
		}
		if (organizedSplitData[stateToSaveIn].Count > 0) {
			organizedSplitData[stateToSaveIn].Clear();
		}
		theStates[stateToSaveIn].Clear();
		foreach (Transform go in parentOfLaundryFormation.GetComponentInChildren<Transform>()) {
			if (go.gameObject.activeInHierarchy) {
				theStates[stateToSaveIn].Add(go.gameObject);
				organizedSplitData[stateToSaveIn].Add(go.gameObject.name);
			}
		}

		SaveToText();
	}

	private void SaveToText() {
		System.IO.File.WriteAllText("Assets/Resources/LevelDesignSave.txt", ConvertDataToString());
	}

	private string ConvertDataToString() {
		string allDataToSave = "";
		for (int i = 0; i < theStates.Length; i++) {
			allDataToSave = string.Concat(allDataToSave, (i == 0 ? "" : ":") + i.ToString());

			for (int u = 0; u < organizedSplitData[i].Count; u++) {
				allDataToSave = string.Concat(allDataToSave, "," + organizedSplitData[i][u]);
			}
		}
		return allDataToSave;
	}

	public void ShowAll() {
		foreach (Transform go in parentOfLaundryFormation.GetComponentInChildren<Transform>()) {
			go.gameObject.SetActive(true);
		}
	}

	public void HideAll() {
		foreach (Transform go in parentOfLaundryFormation.GetComponentInChildren<Transform>()) {
			go.gameObject.SetActive(false);
		}
	}

	public void ShowState(int stateToShow) {
		if (StatesInit()) {
			HideAll();
			for (int i = 0; i < theStates[stateToShow].Count; i++) {
				theStates[stateToShow][i].SetActive(true);
			}
		}
	}

	public void LoadAllStates() {
		if (!StatesInit()) {
			InittheStates();
		}
		ReadText();
		ShowAll();
		for (int i = 0; i < splitData.Length; i++) {
			if (organizedSplitData[i].Count > 0) {
				for (int u = 0; u < organizedSplitData[i].Count; u++) {
					if (organizedSplitData[i][u].Length > 0) {
						if (Char.GetNumericValue(organizedSplitData[i][u][0]) < 0) {
							theStates[i].Add(GameObject.Find(organizedSplitData[i][u]));
						}		
					}
				}
			}
		}
	}

	private void ReadText() {
		allData = System.IO.File.ReadAllText("Assets/Resources/LevelDesignSave.txt");
		splitData = allData.Split(':');
		organizedSplitData = new List<string>[splitData.Length];
		for (int i = 0; i < splitData.Length; i++) {
			string[] temp = splitData[i].Split(',');
			organizedSplitData[i] = new List<string>();
			if (temp.Length > 0) {
				for (int u = 0; u < temp.Length; u++) {
					organizedSplitData[i].Add(temp[u]);
				}
			}
		}
	}
}
