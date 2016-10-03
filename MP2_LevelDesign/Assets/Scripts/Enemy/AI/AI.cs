using UnityEngine;

public interface AI {
	void SetPlayer(GameObject playerObj);
	void SetEnemy(Enemy enemy);
	void SetControllable(Controllable controllable);
}
