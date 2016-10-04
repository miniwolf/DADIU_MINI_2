using UnityEngine;
using System.Collections;

public class CatchGirlAction : Action {
	NavMeshAgent agent;
	private Enemy enemy;

	public CatchGirlAction(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}


	public void Execute() {
		enemy.SetState(EnemyState.GirlCaught);
		agent.Stop();
	}
}
