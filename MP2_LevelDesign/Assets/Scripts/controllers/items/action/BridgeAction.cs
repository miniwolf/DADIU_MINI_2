using UnityEngine;
using System.Collections;

public class BridgeAction : ItemCommand {
	private Enemy enemy;
	private GameObject bridgeObject;
	private CoroutineDelegateContainer coroutineDelegator;
	private GameObject woodBridgeNavMesh;

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
				if (child.GetComponent<Rigidbody>() != null) {
					child.GetComponent<Rigidbody>().isKinematic = false;	
				}
			}

			woodBridgeNavMesh = GameObject.FindGameObjectWithTag(TagConstants.WOODBRIDGENAVMESH);
			woodBridgeNavMesh.GetComponent<NavMeshObstacle>().enabled = true;
			woodBridgeNavMesh.transform.parent = null;
			enemy.SetState(EnemyState.RandomWalk);
			coroutineDelegator.StartCoroutine(RemoveBridgeAfterTime());
		}
	}

	private IEnumerator RemoveBridgeAfterTime() {
		yield return new WaitForSeconds(bridgeObject.GetComponent<Bridge>().timeForBrokenBridgeToDisappear);
		bridgeObject.SetActive(false);
	}
}
