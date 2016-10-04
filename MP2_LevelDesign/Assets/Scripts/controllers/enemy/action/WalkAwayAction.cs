using UnityEngine;
using System.Collections;

public class WalkAwayAction : Action {
	private Enemy enemy;

	public WalkAwayAction(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
	}


	public void Execute() {
		enemy.SetState(EnemyState.WalkAway);
	}
}
