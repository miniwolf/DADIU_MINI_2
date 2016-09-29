using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	public Image mainMenu;
	public Image settingsMenu;
	public Image inGameMenu;

	private GameStateManager gameStateManager;

	//private MenuController mainMenuController;

	void Awake() {
		//mainMenuController = GameObject.FindGameObjectWithTag(UIConstants.MAIN_MENU).GetComponent<MenuController>() as MenuController;
		//mainMenuController.ShowMainMenu();
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>() as GameStateManager;
		ShowMainMenu();
	}


	public void ShowMainMenu() {
		mainMenu.gameObject.SetActive(true);
		settingsMenu.gameObject.SetActive(false);
		inGameMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowSettings() {
		settingsMenu.gameObject.SetActive(true);
		mainMenu.gameObject.SetActive(false);
		inGameMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowPlayGame() {
		inGameMenu.gameObject.SetActive(true);
		mainMenu.gameObject.SetActive(false);
		settingsMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Playing);
	}

}
