using UnityEngine;
using System.Collections;

public class DressAction : ItemCommand {
	private GameObject dress;
	private InGameController inGameController;
	private Actionable actionableEnemy;
	private Enemy enemy;

	public DressAction(InGameController inGameController, Actionable actionableEnemy, Enemy enemy) {
		this.enemy = enemy;
		this.actionableEnemy = actionableEnemy;
		this.inGameController = inGameController;
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
			PickupCloth();
			SpeedUpTroll();
		}
	}

	/// <summary>
	/// Remove the cloth from the game and updates the score.
	/// </summary>
	private void PickupCloth() {
		dress.SetActive(false);
		inGameController.IncrementScore();
	}

	/// <summary>
	/// Increases speed of troll every thresholdSpeedup points
	/// </summary>
	void SpeedUpTroll() {
		if ( (int)inGameController.GetScoreValue() % enemy.GetThresholdSpeedup() == 0 ) {
			actionableEnemy.ExecuteAction(Actions.SPEEDUP);
		}
		if ( (int)inGameController.GetScoreValue() % enemy.GetThresholdChase() == 0 ) {
			enemy.SetState(EnemyState.CatchGirl);
		}
	}
}
