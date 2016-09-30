using UnityEngine;
using System.Collections;

public abstract class InGameController : UIController {
	abstract public void RetryLevel();
	abstract public void ShowMainMenu();
}
