using UnityEngine;
using System.Collections;

public abstract class InGameController : UIController {
	abstract public void RetryLevel();
	abstract public void ShowMainMenu();

	abstract public void IncrementLife();
	abstract public void IncrementScore();

	abstract public void DecrementLife();
	abstract public void DecrementScore();
}
