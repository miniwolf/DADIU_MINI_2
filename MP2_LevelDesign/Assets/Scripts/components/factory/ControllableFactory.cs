using UnityEngine;

public class ControllableFactory {
	private NavMeshAgent playerAgent, enemyAgent;
	private GameObject playerObj, enemyObj;
	private Player player;
	private Enemy enemy;
	private Camera camera;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;
	private InGameControllerImpl ingameController;

	CoroutineDelegateContainer container;

	public ControllableFactory(CoroutineDelegateContainer container) {
		this.container = container;
		playerObj = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		playerAgent = playerObj.GetComponent<NavMeshAgent>();
		player = playerObj.GetComponent<Player>();

		camera = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
		ingameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameControllerImpl>();

		enemyObj = GameObject.FindGameObjectWithTag(TagConstants.ENEMY);
		enemyAgent = enemyObj.GetComponent<NavMeshAgent>();
		enemy = enemyObj.GetComponent<Enemy>();

		gameObj = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE);
	}

	public void CreatePlayer(Actionable player) {
		player.AddAction(Actions.MOVE, CreateMovementAuntie(player));
		player.AddAction(Actions.STUN, CreateStun(player));
		player.AddAction(Actions.CAUGHT, CreateCaught(player));

		new LifeCommander(playerObj.GetComponent<Player>(), enemyObj.GetComponent<Enemy>(), gameObj.GetComponent<GameStateManager>(), inGameController)
		playerObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand();
	}

	private Handler CreateCaught(Actionable actionable) {
		Handler caught = new GotCaughtHandler();
		caught.AddAction(new GotCaught(ingameController, player));
		caught.AddAction(new GotCaughtSound());
		return caught;
	}

	private Handler CreateStun(Actionable player) {
		Handler stun = new Stun();
		stun.AddAction(new StunnedAction());
		stun.AddAction(new StopMovingAuntieSound());
		return stun;
	}

	private Handler CreateMovementAuntie(Actionable controllable) {
		Handler move = new MouseMove(player);
		move.AddAction(new StartMovingAuntieSound());
		move.AddAction(new MoveActionImpl());
		move.AddAction(new TapFeedback(GameObject.FindGameObjectWithTag(TagConstants.TAP_FEEDBACK)));
		return move;
	}

	public void CreateEnemy(Actionable actionable) {
		actionable.AddAction(Actions.SLOWDOWN, CreateSlowDown());
		actionable.AddAction(Actions.MOVE, CreateEnemyMovement());
		//CreateControllable(enemy, enemyAgent,maxSpeedOnTroll);
		enemyObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(new ChaseCommand(enemy));
	}

	public Handler CreateSlowDown() {
		Handler slowdown = new ActionHandler();
		slowdown.AddAction(new SlowDownAction(container, enemy));
		return slowdown;
	}

	Handler CreateEnemyMovement() {
		Handler enemyMovement = new ActionHandler();
		enemyMovement.AddAction(new TrollMove(enemy));
		enemyMovement.AddAction(new TrollMoveSound());
		return enemyMovement;
	}

	public void CreateEnemyAI(AI ai) {
		ai.SetPlayer(playerObj.GetComponent<Player>());
		ai.SetEnemy(enemyObj.GetComponent<Enemy>());
	}
}
