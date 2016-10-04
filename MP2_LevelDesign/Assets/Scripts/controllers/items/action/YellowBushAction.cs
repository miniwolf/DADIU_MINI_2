using UnityEngine;
using System.Collections;

public class YellowBushAction : ItemCommand {
	private Enemy enemy;
	private Actionable actionableEnemy;

	public YellowBushAction(Enemy enemy, Actionable actionableEnemy) {
		this.actionableEnemy = actionableEnemy;
		this.enemy = enemy;
	}

	/// <summary>
	/// When starting a yellow bush should be kinematic
	/// </summary>
	/// <param name="gameObject">Game object of the bridge</param>
	public void Setup(GameObject gameObject) {
	}

	/// <summary>
	/// When hitting the enemy we toggle its state as collider
	/// </summary>
	/// <param name="other">Colliding object</param>
	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.ENEMY ) {
			enemy.SetState(EnemyState.RandomWalk);
			actionableEnemy.ExecuteAction(Actions.SLOWDOWN);
		}
	}
}
