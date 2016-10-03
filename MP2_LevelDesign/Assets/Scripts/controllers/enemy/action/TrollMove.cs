using UnityEngine;
using System.Collections;

public class TrollMove : Action {
	private NavMeshAgent agent;
	private Enemy troll;

	public TrollMove(Enemy enemy) {
		this.troll = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		agent.destination = troll.GetPosition();
	}
}
