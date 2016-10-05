using UnityEngine;
using System.Collections;

public class BridgeAction : ItemCommand {
	private Enemy enemy;
	private GameObject bridgeObject;
	private CoroutineDelegateContainer coroutineDelegator;
	private GameObject woodBridgeNavMesh;
	private Actionable actionableEnemy;

	public BridgeAction(Enemy enemy, CoroutineDelegateContainer corout, Actionable actionableEnemy) {
		this.enemy = enemy;
		this.coroutineDelegator = corout;
		this.actionableEnemy = actionableEnemy;
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
			if (enemy.GetState () == EnemyState.Chasing || enemy.GetState () == EnemyState.StartChase) {
				foreach (Transform child in bridgeObject.GetComponentInChildren<Transform>()) {
					if (child.GetComponent<Rigidbody> () != null) {
						child.GetComponent<Rigidbody> ().isKinematic = false;	
					} else {
						child.GetComponent<NavMeshObstacle> ().enabled = true;
						child.transform.parent = null;
					}
				}
				actionableEnemy.ExecuteAction (Actions.ROAM);
				coroutineDelegator.StartCoroutine (RemoveBridgeAfterTime ());
			}
		}
	}

	private IEnumerator RemoveBridgeAfterTime() {
		yield return new WaitForSeconds(bridgeObject.GetComponent<Bridge>().timeForBrokenBridgeToDisappear);
		bridgeObject.SetActive(false);
	}
}
