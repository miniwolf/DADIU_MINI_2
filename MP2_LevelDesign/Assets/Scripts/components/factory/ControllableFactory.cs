using UnityEngine;

public class ControllableFactory {
	NavMeshAgent playerAgent, enemyAgent;
	GameObject playerObj, enemyObj;
    InGameController inGameController;

    public ControllableFactory() {
		playerObj = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		playerAgent = playerObj.GetComponent<NavMeshAgent>();

		enemyObj = GameObject.FindGameObjectWithTag(TagConstants.ENEMY);
		enemyAgent = enemyObj.GetComponent<NavMeshAgent>();
        
        inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
    }

	public void CreatePlayer(Controllable player) {
        CreateControllable(player, playerAgent);
        playerObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(new LifeCommander(playerObj.GetComponent<Player>(), enemyObj.GetComponent<Enemy>(), inGameController));
    }

	public void CreateEnemy(Controllable enemy, float maxSpeedOnTroll) {
		CreateControllable(enemy, enemyAgent,maxSpeedOnTroll);
		enemyObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(new ChaseCommand(enemyObj.GetComponent<Enemy>()));
	}

	public void CreateEnemyAI(AI ai) {
		ai.SetPlayer(playerObj.GetComponent<Player>());
		ai.SetEnemy(enemyObj.GetComponent<Enemy>());
		ai.SetControllable(enemyObj.GetComponent<Controllable>());
	}

	private void CreateControllable(Controllable controllable, NavMeshAgent agent) {
		if ( agent == null ) {
			Debug.LogError("Game object '" + playerObj.name + "' is missing a navmesh agent");
			return;
		}
		controllable.AddController(new NavMeshController(agent));
	}

	private void CreateControllable(Controllable controllable, NavMeshAgent agent, float maxSpeedOnTroll) {
		if ( agent == null ) {
			Debug.LogError("Game object '" + playerObj.name + "' is missing a navmesh agent");
			return;
		}
		controllable.AddController(new NavMeshController(agent,maxSpeedOnTroll));
	}
}
