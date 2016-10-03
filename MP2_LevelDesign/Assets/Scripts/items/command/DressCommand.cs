using UnityEngine;
using System.Collections;

public class DressCommand : ItemCommand {
	private int thresholdSpeedup;
	private GameObject dress;
	private InGameController inGameController;
	private Enemy enemy;
	private Value feedBackNumber;

	public DressCommand(InGameController inGameController, Enemy enemy,Value feedBackNumber, int thresholdSpeedUp) {
		this.enemy = enemy;
		this.inGameController = inGameController;
		this.feedBackNumber = feedBackNumber;
		this.thresholdSpeedup = thresholdSpeedUp;
	}

	/// <summary>
	/// We need the dress reference to disable the gameobject and potentially call
	/// the object pool
	/// </summary>
	/// <param name="dress">Dress gameobject for instanced dress</param>
	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	/// <summary>
	/// When colliding with the player we will disabled the gameobject.
	/// The score will be updated and the enemy will start chasing the girl.
	/// </summary>
	/// <param name="other">Object colliding with the dress, only responds to player</param>
	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.PLAYER ) {
			dress.SetActive(false);
			updateScore();
			SpeedUp();
		}
	}

	private void updateScore() {
		inGameController.IncrementScore();
		feedBackNumber.IncrementValue();
	}

	/// <summary>
	/// Increases speed of troll every thresholdSpeedup points
	/// </summary>
	private void SpeedUp() {
		if((int)inGameController.GetScoreValue() % thresholdSpeedup == 0) {
			enemy.SetState(EnemyState.Chasing);
			enemy.GetNavMesh().SpeedUp();
		}
	}
}
