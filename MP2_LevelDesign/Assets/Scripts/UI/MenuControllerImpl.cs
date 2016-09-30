using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MenuControllerImpl : MenuController {

	private Text textPlayGame;
	private Text textSettings;
	private Text textExitGame;
	private Text textHowToPlay;

	void OnDestroy () {
		textPlayGame = textSettings = textExitGame = textHowToPlay = null;
	}

	public override  void ShowHowToPlay() {
		canvas.ShowHowToPlayMenu();
		gameStateManager.NewState(GameState.Paused);
	}

	public override  void ShowMainMenu() {
		canvas.ShowMainMenu();
		gameStateManager.NewState(GameState.Paused);
	}

	public override  void ShowSettings() {
		canvas.ShowSettings();
		gameStateManager.NewState(GameState.Paused);
	}

	public override void ShowPlayGame() {
		canvas.ShowPlayGame();
		gameStateManager.NewState(GameState.Playing);
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