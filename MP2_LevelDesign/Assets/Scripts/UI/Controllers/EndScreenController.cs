using UnityEngine;
using System.Collections;

public abstract class EndScreenController : UIController {
	abstract public void ShowFinalScore();
	abstract public void ShowHighScore();
	abstract public void ShowFeedback();
	abstract public void ShowEatCakeTogetherAnimation();
}