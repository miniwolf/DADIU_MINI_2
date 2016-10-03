using UnityEngine;
using System.Collections;

public interface InGameController {
	void RetryLevel();
	void ShowMainMenu();

	void IncrementLife();
	void IncrementScore();

	void DecrementLife();
	void DecrementScore();

	float GetScoreValue();

	void UpdateScore ();

	void SetFeedback (FloatingNumberInterface floatingNumberFeedback);
}
