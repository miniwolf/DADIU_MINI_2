using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	public Image mainMenu;
	public Image settingsMenu;
	public Image inGameMenu;
	public Image howToPlayMenu;

	private GameStateManager gameStateManager;

	private SettingsController settingsController;
	private MenuController menuController;
	private InGameController inGameController;

	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>();
		settingsController = GameObject.FindGameObjectWithTag(UIConstants.SETTINGS_MENU).GetComponent<SettingsController>();
		menuController = GameObject.FindGameObjectWithTag(UIConstants.MAIN_MENU).GetComponent<MenuController>();
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
		ShowMainMenu();
	}


	public void ShowMainMenu() {
		mainMenu.gameObject.SetActive(true);
		settingsMenu.gameObject.SetActive(false);
		inGameMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowSettings() {
		settingsMenu.gameObject.SetActive(true);
		mainMenu.gameObject.SetActive(false);
		inGameMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowPlayGame() {
		inGameMenu.gameObject.SetActive(true);
		mainMenu.gameObject.SetActive(false);
		settingsMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(GameState.Playing);
	}

	public void ShowHowToPlayMenu() {
		inGameMenu.gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(false);
		settingsMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(true);

		gameStateManager.NewState(GameState.Playing);
	}

	public void ReturnToMainMenu() {
		ShowMainMenu();
	}

	public void OnLanguageChanged() {
		SupportedLanguage language = TranslateApi.GetCurrentLanguage();
		if (language.Equals(SupportedLanguage.DEN)) {
			language = SupportedLanguage.ENG;
		}
		else {
			language = SupportedLanguage.DEN;
		}

		TranslateApi.ChangeLanguage(language);

		settingsController.SetTexts();
		menuController.SetTexts();
		Debug.Log("RESOLVE NULL POINTER WHEN LOOKING UP TEXTS IN InGameMenu, THEN YOU CAN TRANSLATE");
		//inGameController.SetTexts(); // TODO fix problems for looking up Texts for the In Game Menu!!! See InGameControllerImpl.cs vs. SettingsControllerImpl.cs
	}
}
