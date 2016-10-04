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
		actionable.AddAction(Actions.STUN, CreateStun());

		MovableCommand life = new LifeCommander(player,
		                                        enemy,
												GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>(),
												ingameController,
												(Actionable) player,
												(Actionable) enemy);
		playerObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(life);
	}

	private Handler CreateStun() {
		Handler stun = new Stun();
		stun.AddAction(new StopAction(player));
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
		move.AddAction(new TapAnimation(tapObj.GetComponent<Animator>()));		

		return move;
	}

	public void CreateEnemy(Actionable actionable) {
		actionable.AddAction(Actions.SLOWDOWN, CreateSlowDown());
		actionable.AddAction(Actions.MOVE, CreateEnemyMovement());
		actionable.AddAction(Actions.STOP, CreateStopEnemy());
		actionable.AddAction(Actions.SPEEDUP, CreateSpeedEnemy());
		actionable.AddAction(Actions.WALKAWAY, CreateWalkAwayEnemy());
		actionable.AddAction(Actions.WARP, CreateWarpEnemy());
		actionable.AddAction(Actions.CAUGHT, CreateCaught());
		//CreateControllable(enemy, enemyAgent,maxSpeedOnTroll);
		enemyObj.GetComponentsInChildren<MovableCommandable>()[0].AddCommand(new ChaseCommand(enemy));
	}

	Handler CreateCaught() {
		Handler catchGirl = new ActionHandler();
		catchGirl.AddAction(new CatchGirlAction(enemy));
		catchGirl.AddAction(new GotCaughtSound());
		return catchGirl;
	}
		
	Handler CreateWalkAwayEnemy() {
		Handler walkaway = new ActionHandler();
		walkaway.AddAction(new WalkAwayAction(enemy));
		return walkaway;
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
		enemyStop.AddAction(new StopAction(player));
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
