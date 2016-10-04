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

	public LifeCommander(Player player, Enemy enemy, GameStateManager gameStateManager, InGameController inGameController, Actionable actionablePlayer, Actionable actionableEnemy) {
		this.actionablePlayer = actionablePlayer;
		this.actionableEnemy = actionableEnemy;
        this.player = player;
        this.enemy = enemy;
        this.gameStateManager = gameStateManager;
        this.inGameController = inGameController;
    }

    public void Execute(Collider other) {
        if ( other.tag != TagConstants.ENEMY ) {
            return;
        }
        if (player.GetState() != PlayerState.Idle) {
            if (inGameController.GetLifeValue() >= 0) {
				actionablePlayer.ExecuteAction(Actions.STUN);
				actionableEnemy.ExecuteAction(Actions.CAUGHT);
                inGameController.DecrementLife();
            } else {
                player.SetState(PlayerState.Dead);
                gameStateManager.NewState(new GameState.Ended());
            }
            enemy.SetState(EnemyState.GirlCaught);
        }
    }
}