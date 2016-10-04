using UnityEngine;
using System.Collections;

public class SpeedUp : Action {
	private NavMeshAgent agent;
	private float speedUp;

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
		if ( agent == null ) {
			Debug.Log("Speed up assigned to '" + obj.name + "' and is missing a navmesh agent");
		}
		speedUp = obj.GetComponent<Enemy>().GetSpeedUp();
	}

	public void Execute() {
		agent.speed += speedUp;
	}
}
