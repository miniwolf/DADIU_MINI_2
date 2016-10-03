using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	public Image mainMenu;
	public Image settingsMenu;
	public Image inGameMenu;
	public Image howToPlayMenu;

	private GameStateManager gameStateManager;

	private UIController settingsController;
	private UIController menuController;
	private UIController inGameController;
	private UIController howToPlayController;

	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>();

		settingsController = GameObject.FindGameObjectWithTag(UIConstants.SETTINGS_MENU).GetComponent<UIController>();
		menuController = GameObject.FindGameObjectWithTag(UIConstants.MAIN_MENU).GetComponent<UIController>();
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<UIController>();

		ShowMainMenu();
	}

	public void ShowMainMenu() {
		menuController.SetVisible();
		settingsController.SetInvisible();
		inGameController.SetInvisible();

		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowSettings() {
		menuController.SetInvisible();
		settingsController.SetVisible();
		inGameController.SetInvisible();

		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowPlayGame() {
		menuController.SetInvisible();
		settingsController.SetInvisible();
		inGameController.SetVisible();

		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Playing);
	}

	public void ShowHowToPlayMenu() {
		menuController.SetInvisible();
		settingsController.SetInvisible();
		inGameController.SetInvisible();
		howToPlayMenu.gameObject.SetActive(true);

		gameStateManager.NewState(GameState.Playing);
	}

	public void ReturnToMainMenu() {
		ShowMainMenu();
	}

	public void OnLanguageChanged() {
		settingsController.RefreshText();
		menuController.RefreshText();
		inGameController.RefreshText();
		// todo on how to play menu
	}
}
