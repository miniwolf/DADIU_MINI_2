using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MenuControllerImpl : MonoBehaviour, MenuController {

	private GameStateManager gameStateManager;
	private CanvasScript canvas;

	private Text textPlayGame;
	private Text textSettings;
	private Text textExitGame;
	private Text textHowToPlay;

	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>() as GameStateManager;
		canvas = GameObject.FindGameObjectWithTag(UIConstants.CANVAS).GetComponent<CanvasScript>();
		SetTexts();	
	}

	void OnDestroy () {
		textPlayGame = textSettings = textExitGame = textHowToPlay = null;
	}

	public void ShowHowToPlay() {
		
	}

	public void ShowMainMenu() {
		canvas.ShowMainMenu();
		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowSettings() {
		canvas.ShowSettings();
		gameStateManager.NewState(GameState.Paused);
	}

	public void ShowPlayGame() {
		canvas.ShowPlayGame();
		gameStateManager.NewState(GameState.Playing);
	}

	private void SetTexts() {
		textPlayGame.text = TranslateApi.GetString(LocalizedString.mainPlayGame);
		textSettings.text = TranslateApi.GetString(LocalizedString.mainSettings);
		textExitGame.text = TranslateApi.GetString(LocalizedString.mainExitGame);
		textHowToPlay.text = TranslateApi.GetString(LocalizedString.mainHowtoPlay);
	}

	private void ResolveDependencies() {
		textPlayGame = GetTextComponent(UIConstants.TEXT_PLAY_GAME);
		textSettings = GetTextComponent(UIConstants.TEXT_SETTINGS);
		textHowToPlay = GetTextComponent(UIConstants.TEXT_HOW_TO_PLAY);
		textExitGame = GetTextComponent(UIConstants.TEXT_EXIT_GAME);
	}

	private Text GetTextComponent(string tag) {
		return GameObject.FindGameObjectWithTag(tag).GetComponent<Text>();
	}
}