using UnityEngine;
using System.Collections;
using System;

public class ScoreImpl : ScoreController {

	private Player player;
	private Life life;
	private Score score;


	public override void RefreshText() {
		throw new NotImplementedException();
	}

	public override void ResolveDependencies() {
		throw new NotImplementedException();
	}

	public override void ShowPoints() {
		throw new NotImplementedException();
	}

	public override void ShowLife() {
		life = player.GetLife();
		// TODO show life on UI element
		throw new NotImplementedException();
	}

	public override void UpdateLife(int cnt) {
		throw new NotImplementedException();
	}

	public override void UpdatePoints(int points) {
		throw new NotImplementedException();
	}

}
