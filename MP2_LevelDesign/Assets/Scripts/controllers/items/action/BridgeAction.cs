using UnityEngine;
using System.Collections;

public class BridgeAction : ItemCommand {
	private Enemy enemy;
	private GameObject bridgeObject;

	public BridgeAction(Enemy enemy) {
		this.enemy = enemy;
	}

	/// <summary>
	/// When starting a bridge should be kinematic
	/// </summary>
	/// <param name="gameObject">Game object of the bridge</param>
	public void Setup(GameObject gameObject) {
		this.bridgeObject = gameObject;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
	}

	/// <summary>
	/// When hitting the enemy we toggle its state as collider
	/// </summary>
	/// <param name="other">Colliding object</param>
	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.ENEMY ) {
			bridgeObject.GetComponent<Rigidbody>().isKinematic = false;
			enemy.SetState(EnemyState.RandomWalk);
		}
	}
}
