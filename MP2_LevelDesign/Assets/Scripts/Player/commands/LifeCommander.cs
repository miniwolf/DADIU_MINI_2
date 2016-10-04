using UnityEngine;
using System.Collections;
using System;

public class LifeCommander : MovableCommand {
    InGameController inGameController;
    GameStateManager gameStateManager;
    Player player;
	Enemy enemy;
	Actionable actionablePlayer;
	Actionable actionableEnemy;
	CoroutineDelegateContainer container;

	public LifeCommander(Player player, Enemy enemy, GameStateManager gameStateManager, InGameController inGameController, Actionable actionablePlayer, Actionable actionableEnemy, CoroutineDelegateContainer container) {
		this.actionablePlayer = actionablePlayer;
		this.actionableEnemy = actionableEnemy;
        this.player = player;
        this.enemy = enemy;
        this.gameStateManager = gameStateManager;
        this.inGameController = inGameController;
		this.container = container;
    }

    public void Execute(Collider other) {
        if ( other.tag != TagConstants.ENEMY ) {
            return;
        }
        if (player.GetState() != PlayerState.Idle) {
			inGameController.DecrementLife();
            if (inGameController.GetLifeValue() > 0) {
				actionablePlayer.ExecuteAction(Actions.STUN);
				actionableEnemy.ExecuteAction(Actions.CAUGHT);
            } else {
                player.SetState(PlayerState.Dead);
                gameStateManager.NewState(new GameState.Ended());
            }
			//Possibly change this to react according to the animation
			container.StartCoroutine(ReactivateGirl());
			enemy.SetState(EnemyState.GirlCaught);
        }
    }
	private IEnumerator ReactivateGirl() {
		yield return new WaitForSeconds(2.5f);
		actionablePlayer.ExecuteAction(Actions.RESUME);
		actionableEnemy.ExecuteAction(Actions.WALKAWAY);
	}
}