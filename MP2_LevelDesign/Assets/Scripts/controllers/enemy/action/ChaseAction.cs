using UnityEngine;
using System.Collections;

public class ChaseAction : Action {
	NavMeshAgent agent;
	private Enemy enemy;

	public ChaseAction(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		enemy.SetState(EnemyState.Chasing);
		//agent.speed = enemy.GetChaseSpeed();
	}
}
