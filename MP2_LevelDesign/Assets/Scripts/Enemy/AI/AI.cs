using UnityEngine;

public interface AI {
	void SetPlayer(Player playerObj);
	void SetEnemy(Enemy enemy);

	void SetActionablePlayer(Actionable actionablePlayer);
	void SetActionableEnemy(Actionable actionableEnemy);
}
