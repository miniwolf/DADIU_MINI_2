using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MenuControllerImpl : UIController, MenuController {
	private Text textPlayGame;
	private Text textSettings;
	private Text textExitGame;
	private Text textHowToPlay;

	public void ShowHowToPlay() {
		canvas.ShowHowToPlayMenu();
	}

	public void ShowMainMenu() {
		canvas.ShowMainMenu();
	}

	public void ShowSettings() {
		canvas.ShowSettings();
	}

	public void ShowPlayGame() {
		canvas.ShowPlayGame();
	}

	public void ExitGame() {
		Application.Quit(); // Note: Needs testing for Android
		Debug.Log("TEST ON TABLET");
	}

	public override void RefreshText() {
		textPlayGame.text = TranslateApi.GetString(LocalizedString.mainPlayGame);
		textSettings.text = TranslateApi.GetString(LocalizedString.mainSettings);
		textExitGame.text = TranslateApi.GetString(LocalizedString.mainExitGame);
		textHowToPlay.text = TranslateApi.GetString(LocalizedString.mainHowtoPlay);
	}

	public override void ResolveDependencies() {
		textPlayGame = GetTextComponent(UIConstants.TEXT_PLAY_GAME);
		textSettings = GetTextComponent(UIConstants.TEXT_SETTINGS);
		textHowToPlay = GetTextComponent(UIConstants.TEXT_HOW_TO_PLAY);
		textExitGame = GetTextComponent(UIConstants.TEXT_EXIT_GAME);
	}
}