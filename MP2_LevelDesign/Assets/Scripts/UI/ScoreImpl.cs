using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreImpl : ScoreController {

	private Player player;
	private Text scoreText;
	private Life life;

	void Start() {
		TagRegister.RegisterSingle(gameObject, TagConstants.SCORE);
		scoreText = GetComponent<Text>();
	}

	public override void RefreshText() {
		throw new NotImplementedException();
	}

	public override void ResolveDependencies() {
		throw new NotImplementedException();
	}

	public override void ShowPoints() {
//		scoreText.text = "Dresses: " + GetValue().ToString();
		if (Input.GetKey(KeyCode.K)) {
			scoreText.text = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE).ToString();
		}
	}

	public override void ShowLife() {
		life = player.GetLife();
		// TODO show life on UI element
		throw new NotImplementedException();
	}

	public override void UpdateLife(int cnt) {
		throw new NotImplementedException();
	}

	void Update() {
		ShowPoints();
	}

	public override void UpdatePoints(int points) {
		throw new NotImplementedException();
	}
}
