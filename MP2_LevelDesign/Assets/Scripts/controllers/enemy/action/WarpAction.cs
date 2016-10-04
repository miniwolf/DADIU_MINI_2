using UnityEngine;
using System.Collections;

public class WarpAction : Action {
	private NavMeshAgent agent;
	private Enemy enemy;

	public WarpAction(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		this.agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		agent.Warp(enemy.GetDestination());
	}
}
