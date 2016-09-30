using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameControllerImpl : InGameController {
	private Text textExit;
	private Text textRetry;
	private Text textScoreCounter;
	private Text textLifeCounter;

	private Player player;

	private Life life = new Life();
	private Score score = new Score();

	void OnStart() {
		TagRegister.RegisterSingle(gameObject, TagConstants.SCORE);
	}

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
	}

	private void UpdateLife() {
		textLifeCounter.text = TranslateApi.GetString(LocalizedString.ingameScore) + life.GetValue();
	}

	private void UpdateScore() {
//		if (Input.GetKey(KeyCode.K)) {
//			textScoreCounter.text = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE).ToString();
//		}
		textScoreCounter.text = TranslateApi.GetString(LocalizedString.ingameLife) + score.GetValue();
	}

	public override void IncrementLife() {
		life.IncrementValue();
		UpdateLife();
	}

	public override void IncrementScore() {
		score.IncrementValue();
		UpdateScore();
	}

	public override void DecrementLife() {
		life.DecrementValue();
		UpdateLife();
	}

	public override void DecrementScore() {
		score.DecrementValue();
		UpdateScore();
	}
}
