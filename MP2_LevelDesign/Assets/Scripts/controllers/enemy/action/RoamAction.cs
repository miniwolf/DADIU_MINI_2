using UnityEngine;
using System.Collections;

public class RoamAction : Action {
	NavMeshAgent agent;
	private Enemy enemy;

	public RoamAction(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		enemy.SetState(EnemyState.RandomWalk);
		agent.speed = enemy.GetRoamSpeed();
	}
}
