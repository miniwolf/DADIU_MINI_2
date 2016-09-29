﻿using UnityEngine;
using System.Collections;

public class DressCommand : ItemCommand {
	private GameObject dress;
	private Score score;
	private ScoreController scoreController;
	private Enemy enemy;

	public DressCommand(Score score, ScoreController scoreController, Enemy enemy) {
		this.enemy = enemy;
		this.score = score;
		this.scoreController = scoreController;
	}

	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.PLAYER ) {
			dress.SetActive(false);
			//updateScore();
			enemy.SetState(EnemyState.Chasing);
			enemy.GetNavMesh().SpeedUp();
		}
	}

	private void updateScore() {
		score.IncrementValue();
		scoreController.ShowPoints();
	}
}
