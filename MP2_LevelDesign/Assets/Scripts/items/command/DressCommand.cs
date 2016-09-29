using UnityEngine;
using System.Collections;

public class DressCommand : ItemCommand {
	private GameObject dress;
	private Value score;
	private Enemy enemy;

	public DressCommand(Value score, Enemy enemy) {
		this.enemy = enemy;
		this.score = score;
	}

	/// <summary>
	/// We need the dress reference to disable the gameobject and potentially call
	/// the object pool
	/// </summary>
	/// <param name="dress">Dress gameobject for instanced dress</param>
	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	/// <summary>
	/// When colliding with the player we will disabled the gameobject.
	/// The score will be updated and the enemy will start chasing the girl.
	/// </summary>
	/// <param name="other">Object colliding with the dress, only responds to player</param>
	public void Execute(Collider other) {
		if ( other.transform.tag == TagConstants.PLAYER ) {
			dress.SetActive(false);
			updateScore();
			enemy.SetState(EnemyState.Chasing);
			enemy.GetNavMesh().SpeedUp();
		}
	}

	private void updateScore() {
		score.IncrementValue();
	}
}
