using UnityEngine;

public class ChasingMusic : Action {
	private GameObject obj;
	private Enemy enemy;

	public ChasingMusic(Enemy enemy) {
		this.enemy = enemy;
	}

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		if ( enemy.GetState() != EnemyState.Chasing ) {
			AkSoundEngine.PostEvent("playChasingMusic", obj);
		}
	}
}
