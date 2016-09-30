using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameControllerImpl : InGameController {
	private Text textExit;
	private Text textRetry;
	private Text textScoreCounter;
	private Text textLifeCounter;

	public override void RefreshText() {
		textExit.text = TranslateApi.GetString(LocalizedString.ingameExit);
		textRetry.text = TranslateApi.GetString(LocalizedString.ingameRetry);
		textScoreCounter.text = TranslateApi.GetString(LocalizedString.ingameScore);
		textLifeCounter.text = TranslateApi.GetString(LocalizedString.ingameLife);
	}

	public override void ResolveDependencies() {
		textExit = GetTextComponent(UIConstants.TEXT_EXIT);
		textRetry = GetTextComponent(UIConstants.TEXT_RETRY);
		textScoreCounter = GetTextComponent(UIConstants.TEXT_SCORE_COUNTER);
		textLifeCounter = GetTextComponent(UIConstants.TEXT_LIFE_COUNTER);
	}

	public override void RetryLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public override void ShowMainMenu() {
		canvas.ShowMainMenu();
		gameStateManager.NewState(GameState.Paused);
	}
}
