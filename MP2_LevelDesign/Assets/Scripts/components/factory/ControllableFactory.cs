using UnityEngine;

public class ControllableFactory {
	private GameObject playerObj, enemyObj;
	private Player player;
	private Enemy enemy;
	private Camera camera;

	private InGameControllerImpl ingameController;

	CoroutineDelegateContainer container;

	public ControllableFactory(CoroutineDelegateContainer container) {
		this.container = container;
		playerObj = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		player = playerObj.GetComponent<Player>();

		camera = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
		ingameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameControllerImpl>();

		enemyObj = GameObject.FindGameObjectWithTag(TagConstants.ENEMY);
		enemy = enemyObj.GetComponent<Enemy>();
	}

	public void CreatePlayer(Actionable actionable) {
		actionable.AddAction(Actions.MOVE, CreateMovementAuntie(actionable));
		actionable.AddAction(Actions.STUN, CreateStun(actionable));
		actionable.AddAction(Actions.CAUGHT, CreateCaught(actionable));

		MovableCommand life = new LifeCommander(player,
		                                        enemy,
		                                        GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>(),
		                                        ingameController);
		//playerObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(life);
	}

	private Handler CreateCaught(Actionable actionable) {
		Handler caught = new GotCaughtHandler();
		caught.AddAction(new GotCaught(ingameController, player));
		caught.AddAction(new GotCaughtSound());
		return caught;
	}

	private Handler CreateStun(Actionable player) {
		Handler stun = new Stun();
		stun.AddAction(new StopAction());
		stun.AddAction(new StopMovingAuntieSound());
		return stun;
	}

	private MouseMove CreateMovementAuntie(Actionable controllable) {
		MouseMove move = new MouseMove(camera);
		move.AddAction(new StartMovingAuntieSound());
		move.AddMoveAction(new MoveActionImpl());
		move.AddAction(new AuntieRunAnimation());

		GameObject tapObj = GameObject.FindGameObjectWithTag(TagConstants.TAP_FEEDBACK);
		move.AddMoveAction(new TapFeedback(tapObj));
		//move.AddAction(new TapAnimation(tapObj.GetComponent<Animator>()));
		return move;
	}

	public void CreateEnemy(Actionable actionable) {
		actionable.AddAction(Actions.SLOWDOWN, CreateSlowDown());
		actionable.AddAction(Actions.MOVE, CreateEnemyMovement());
		actionable.AddAction(Actions.STOP, CreateStopEnemy());
		actionable.AddAction(Actions.SPEEDUP, CreateSpeedEnemy());
		actionable.AddAction(Actions.WARP, CreateWarpEnemy());
		//CreateControllable(enemy, enemyAgent,maxSpeedOnTroll);
		enemyObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(new ChaseCommand(enemy));
	}

	Handler CreateWarpEnemy() {
		Handler warp = new ActionHandler();
		warp.AddAction(new WarpAction(enemy));
		return warp;
	}

	private Handler CreateSpeedEnemy() {
		Handler speedUp = new ActionHandler();
		speedUp.AddAction(new SpeedUpAction());
		return speedUp;
	}

	public Handler CreateSlowDown() {
		Handler slowdown = new ActionHandler();
		slowdown.AddAction(new SlowDownAction(container, enemy));
		return slowdown;
	}

	private Handler CreateEnemyMovement() {
		Handler enemyMovement = new ActionHandler();
		enemyMovement.AddAction(new TrollMove(enemy));
		enemyMovement.AddAction(new TrollMoveSound());
		return enemyMovement;
	}

	private Handler CreateStopEnemy() {
		Handler enemyStop = new ActionHandler();
		enemyStop.AddAction(new StopAction());
		enemyStop.AddAction(new StopTrollSound());
		return enemyStop;
	}

	public void CreateEnemyAI(AI ai) {
		ai.SetPlayer(player);
		ai.SetActionablePlayer((Actionable) player);
		ai.SetEnemy(enemy);
		ai.SetActionableEnemy((Actionable) enemy);
	}
}
