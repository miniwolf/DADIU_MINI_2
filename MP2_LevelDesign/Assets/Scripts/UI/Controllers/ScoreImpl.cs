using UnityEngine;
using System.Collections;
using System;

public class ScoreImpl : ScoreController {
	private Player player;
	private Life life;
	private Score score;

	public void ShowLife() {
		life = player.GetLife();
		// TODO show life on UI element
		throw new NotImplementedException();
	}

	public void ShowPoints() {
		throw new NotImplementedException();
	}
}
