using UnityEngine;
using System.Collections;

public class BridgeAction : ItemCommand {
	private Enemy enemy;
	private GameObject bridgeObject;
	private CoroutineDelegateContainer coroutineDelegator;

	public BridgeAction(Enemy enemy, CoroutineDelegateContainer corout) {
		this.enemy = enemy;
		this.coroutineDelegator = corout;
	}

	/// <summary>
	/// When starting a bridge should be kinematic
	/// </summary>
	/// <param name="gameObject">Game object of the bridge</param>
	public void Setup(GameObject gameObject) {
		this.bridgeObject = gameObject;
	}

	/// <summary>
	/// When hitting the enemy we toggle its state as collider
	/// </summary>
	/// <param name="other">Colliding object</param>
	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.ENEMY ) {
			foreach (Transform child in bridgeObject.GetComponentInChildren<Transform>()) {
				child.GetComponent<Rigidbody>().isKinematic = false;	
			}
			enemy.SetState(EnemyState.RandomWalk);
			coroutineDelegator.StartCoroutine(RemoveBridgeAfterTime());
		}
	}

	private IEnumerator RemoveBridgeAfterTime() {
		yield return new WaitForSeconds(bridgeObject.GetComponent<Bridge>().timeForBrokenBridgeToDisappear);
		bridgeObject.SetActive(false);
	}



}
