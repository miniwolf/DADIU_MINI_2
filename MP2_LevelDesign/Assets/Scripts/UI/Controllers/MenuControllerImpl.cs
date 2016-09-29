using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MenuControllerImpl : MonoBehaviour, MenuController {
	// TODO needs ref to UI elements
	public Image mainMenu;
	public Image settingsMenu;
	public Image inGameMenu;

	private GameStateManager gameStateManager;

	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>() as GameStateManager;
	}

	public void ShowHowToPlay() {
		// TODO add to Canvas prefab a tutorial window first
		throw new NotImplementedException();
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