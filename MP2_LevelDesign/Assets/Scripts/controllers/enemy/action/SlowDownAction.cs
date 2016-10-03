using UnityEngine;
using System.Collections;

public class SlowDownAction : Action {
	private NavMeshAgent agent;
	private Enemy enemy;
	private CoroutineDelegateContainer container;

	public SlowDownAction(CoroutineDelegateContainer container, Enemy enemy) {
		this.container = container;
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		container.StartCoroutine(SlowDown());
	}

	IEnumerator SlowDown() {
		agent.speed -= enemy.GetSlowdown();
		yield return new WaitForSeconds(enemy.GetSlowdownTime());
		agent.speed += enemy.GetSlowdown();
	}
}

