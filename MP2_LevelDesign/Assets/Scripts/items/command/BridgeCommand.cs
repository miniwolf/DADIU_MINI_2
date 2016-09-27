using UnityEngine;
using System.Collections;

public class BridgeCommand : ItemCommand {
	private Enemy enemy;

	public BridgeCommand(Enemy enemy) {
		this.enemy = enemy;
	}

	/// <summary>
	/// When starting a bridge should be kinematic
	/// </summary>
	/// <param name="gameObject">Game object of the bridge</param>
	public void Setup(GameObject gameObject) {
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
	}

	/// <summary>
	/// When hitting the enemy we toggle its state as collider
	/// </summary>
	/// <param name="other">Colliding object</param>
	public void Execute(Collision other) {
		if ( other.transform.tag == TagConstants.ENEMY ) {
			enemy.SetState(EnemyState.ObstacleHit);
		}
	}
}
