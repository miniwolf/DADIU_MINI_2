using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreImpl : Score, ScoreController {
	private Player player;
	private Text scoreText;

	void Start() {
		TagRegister.RegisterSingle(gameObject, TagConstants.SCORE);
		scoreText = GetComponent<Text>();
	}

	void Update() {
		ShowPoints();
		if (Input.GetKey(KeyCode.K)) {
			scoreText.text = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE).ToString();
		}
	}

	public void ShowPoints() {
		scoreText.text = "Dresses: " + GetValue().ToString();

	}
}
