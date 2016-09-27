using UnityEngine;
using System.Collections;
using System;

public class ScoreImpl : ScoreController {
	private Player player;
	private Life life;

	public void ShowLife() {
		life = player.GetLife();
		// TODO show life on UI element
	}

	public void ShowPoints() {
		throw new NotImplementedException();
	}
}
