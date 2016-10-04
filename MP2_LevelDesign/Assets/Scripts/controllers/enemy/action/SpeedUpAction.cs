using UnityEngine;
using System.Collections;

public class SpeedUpAction : Action {
	private NavMeshAgent agent;
	private float speedUp;
	private Enemy enemy;

	public SpeedUpAction(Enemy enemy){
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
		if ( agent == null ) {
			Debug.Log("Speed up assigned to '" + obj.name + "' and is missing a navmesh agent");
		}
		speedUp = obj.GetComponent<Enemy>().GetSpeedUp();
	}

	public void Execute() {
		Debug.Log (enemy.GetMaxSpeed ());
		Debug.Log (agent.speed);
		Debug.Log (speedUp);

		if (enemy.GetMaxSpeed() > agent.speed + speedUp) {			
			agent.speed += speedUp;
		}
	}
}
