using UnityEngine;
using System.Collections;
using System;

public class LifeCommander : MovableCommand {
    InGameController inGameController;
    GameStateManager gameStateManager;
    Player player;
    Enemy enemy;

    public LifeCommander(Player player, Enemy enemy, GameStateManager gameStateManager, InGameController inGameController) {
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
                player.SetState(PlayerState.Idle);
                inGameController.DecrementLife();
            } else {
                player.SetState(PlayerState.Dead);
                gameStateManager.NewState(new GameState.End());
            }
            enemy.SetState(EnemyState.GirlCaught);
        }
    }
}