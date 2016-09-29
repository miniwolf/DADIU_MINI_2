using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	private MenuController mainMenuController;

	void Awake() {
		mainMenuController = GameObject.FindGameObjectWithTag(UIConstants.MAIN_MENU).GetComponent<MenuController>() as MenuController;
		mainMenuController.ShowMainMenu();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
