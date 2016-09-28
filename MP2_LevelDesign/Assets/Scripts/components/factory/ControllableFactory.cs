﻿using UnityEngine;

public class ControllableFactory {
	NavMeshAgent playerAgent, enemyAgent;
	GameObject playerObj, enemyObj;

	public ControllableFactory() {
		Debug.Log(GameObject.FindGameObjectWithTag(TagConstants.PLAYER));
		playerObj = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		playerAgent = playerObj.GetComponent<NavMeshAgent>();

		enemyObj = GameObject.FindGameObjectWithTag(TagConstants.ENEMY);
		enemyAgent = enemyObj.GetComponent<NavMeshAgent>();
	}

	public void CreatePlayer(Controllable player) {
		CreateControllable(player, playerAgent);
	}

	public void CreateEnemy(Controllable enemy) {
		CreateControllable(enemy, enemyAgent);
	}

	private void CreateControllable(Controllable controllable, NavMeshAgent agent) {
		if ( agent == null ) {
			Debug.LogError("Game object '" + playerObj.name + "' is missing a navmesh agent");
			return;
		}
		controllable.AddController(new NavMeshController(agent));
	}
}
