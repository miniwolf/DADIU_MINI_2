using UnityEngine;
using System.Collections;

public class DressCommand : ItemCommand {
	private GameObject dress;
	private Score score;
	private ScoreController scoreController;

	public DressCommand(Score score, ScoreController scoreController) {
		this.score = score;
		this.scoreController = scoreController;
	}

	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	public void Execute(Collision other) {
		if ( other.transform.tag == TagConstants.PLAYER ) {
			//dress.SetActive(false);
			updateScore();
		}
	}

	private void updateScore() {
		score.IncrementValue();
		scoreController.ShowPoints();
	}
}
