using UnityEngine;
using System.Collections;

public abstract class MenuController : UIController {
	abstract public void ShowPlayGame();
	abstract public void ShowMainMenu();
	abstract public void ShowHowToPlay();
	abstract public void ShowSettings();
}