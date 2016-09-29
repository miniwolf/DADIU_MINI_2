using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreImpl : Score, ScoreController {
	private Player player;
	private Life life;
	private Score score1;
	private Text scoreText;

	void Start(){
		scoreText = GetComponent<Text>();
	}
	void Update(){
		ShowPoints();
		if (Input.GetKey(KeyCode.K)) {
			scoreText.text = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE).ToString();
		}
	}

	public void ShowLife() {
		life = player.GetLife();
		// TODO show life on UI element
		throw new NotImplementedException();
	}

	public void ShowPoints() {
		scoreText.text = GetValue().ToString();
	}
}
