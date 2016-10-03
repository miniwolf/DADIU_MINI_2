using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameControllerImpl : UIController, InGameController {
	private Text textExit;
	private Text textRetry;
	private Text textScoreCounter;
	private Text textLifeCounter;

	private Player player;
	private Score score =  new Score();
	private Life life = new Life();
	private FloatingNumberInterface feedBackNumber;

	public override void RefreshText() {
		textExit.text = TranslateApi.GetString(LocalizedString.ingameExit);
		textRetry.text = TranslateApi.GetString(LocalizedString.ingameRetry);
		textScoreCounter.text = TranslateApi.GetString(LocalizedString.ingameScore);
		textLifeCounter.text = TranslateApi.GetString(LocalizedString.ingameLife);
		UpdateScore();
		UpdateLife();
	}

	public override void ResolveDependencies() {
		textExit = GetTextComponent(UIConstants.TEXT_EXIT);
		textRetry = GetTextComponent(UIConstants.TEXT_RETRY);
		textScoreCounter = GetTextComponent(UIConstants.TEXT_SCORE_COUNTER);
		textLifeCounter = GetTextComponent(UIConstants.TEXT_LIFE_COUNTER);
	}

	public void RetryLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ShowMainMenu() {
		canvas.ShowMainMenu();
	}

	private void UpdateLife() {
		textLifeCounter.text = TranslateApi.GetString(LocalizedString.ingameLife) + life.GetValue();
	}

	public void UpdateScore() {
//		if (Input.GetKey(KeyCode.K)) {
//			textScoreCounter.text = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE).ToString();
//		}

		textScoreCounter.text = TranslateApi.GetString(LocalizedString.ingameScore) + score.GetValue();
	}

	public void IncrementLife() {
		life.IncrementValue();
		UpdateLife();
	}

	public void IncrementScore() {
		score.IncrementValue();
		feedBackNumber.IncrementValue();
	}

	public void DecrementLife() {
		life.DecrementValue();
		UpdateLife();
	}

	public void DecrementScore() {
		score.DecrementValue();
		UpdateScore();
	}

	public float GetScoreValue() {
		return score.GetValue();
	}

	public void SetFeedback(FloatingNumberInterface feedBackNumber) {
		this.feedBackNumber = feedBackNumber;
	}
}
