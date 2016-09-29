using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameControllerImpl : MonoBehaviour, InGameController {
	private Text textExit;
	private Text textRetry;
	private Text textScoreCounter;
	private Text textLifeCounter;
	private CanvasScript canvas;
	private GameStateManager gameStateManager;


	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>() as GameStateManager;
		ResolveDependencies();
	}

	public void ShowMainMenu() {
		canvas.ShowMainMenu();
		gameStateManager.NewState(GameState.Paused);
	}

	public void RetryLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}


	private void ResolveDependencies() {
		textExit = GetTextComponent(UIConstants.TEXT_EXIT);
		textRetry = GetTextComponent(UIConstants.TEXT_RETRY);
		textScoreCounter = GetTextComponent(UIConstants.TEXT_SCORE_COUNTER);
		textLifeCounter = GetTextComponent(UIConstants.TEXT_LIFE_COUNTER);

		canvas = gameObject.GetComponentInParent<CanvasScript>();
	}

	private Text GetTextComponent(string tag) {
		return GameObject.FindGameObjectWithTag(tag).GetComponent<Text>();
	}

	public void SetTexts() {
		textExit.text = TranslateApi.GetString(LocalizedString.ingameExit);
		textRetry.text = TranslateApi.GetString(LocalizedString.ingameRetry);
		textScoreCounter.text = TranslateApi.GetString(LocalizedString.ingameScore);
		textLifeCounter.text = TranslateApi.GetString(LocalizedString.ingameLife);
	}
}
