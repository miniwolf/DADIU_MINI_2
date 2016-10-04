using UnityEngine;
using System.Collections;

public class ChaseCommand : MovableCommand {
	private Enemy enemy;

	public ChaseCommand(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Execute(Collider other) {
		if ( other.tag == TagConstants.PLAYER ) {
			enemy.SetState(EnemyState.Chasing);
		}
	}
}

