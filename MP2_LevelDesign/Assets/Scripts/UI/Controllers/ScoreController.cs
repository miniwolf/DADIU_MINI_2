using UnityEngine;
using System.Collections;

public abstract class ScoreController : UIController {
	abstract public void ShowPoints();
	abstract public void ShowLife();
	abstract public void UpdateLife(int cnt);
	abstract public void UpdatePoints(int points);
}
