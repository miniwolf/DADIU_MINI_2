using UnityEngine;

public interface AI {
	void SetPlayer(Player playerObj);
	void SetEnemy(Enemy enemy);
	void SetControllable(Controllable controllable);
}
