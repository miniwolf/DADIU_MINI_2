using UnityEngine;
using System.Collections;
using System;

public class Score : Value {
	private float score = 0;

	public void DecrementValue() {
		score--;
	}

	public float GetValue() {
		return score;
	}

	public void IncrementValue() {
		score++;
		//PlayerPrefs.SetFloat(PlayerPrefsConstants.MYSCORE, score);
		//if (PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE) < score) {
	//		PlayerPrefs.SetFloat(PlayerPrefsConstants.HIGHSCORE, score);
	//	}
	}
}
