using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Actionable {
	private PlayerState playerState = PlayerState.Running;
	private Dictionary<Actions, Handler> actions = new Dictionary<Actions, Handler>();

	private NavMeshAgent agent;
	private float stoppingDist = 1f;

	void Awake() {
		agent = this.GetComponent<NavMeshAgent>();
		agent.stoppingDistance = stoppingDist;

		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.PLAYER);
	}

	void Start() {
	}

	public void SetupComponents() {
		foreach ( Handler action in actions.Values ) {
			action.SetupComponents(gameObject);
		}
	}

	void Update() {
		switch ( playerState ) {
			case PlayerState.Running:

				ExecuteAction(Actions.MOVE);
				ExecuteAction(Actions.DEBUGMOVE);

				if(agent.hasPath) {
					if(agent.remainingDistance <= agent.stoppingDistance) {
						ExecuteAction(Actions.STOP);
					}
				}

				break;
			case PlayerState.Idle:
				ExecuteAction(Actions.STUN);
				break;

		}
	}

	public void AddAction(Actions command, Handler action) {
		actions.Add(command, action);
	}

	public void ExecuteAction(Actions name) {
		actions[name].DoAction();
	}

	public void SetState(PlayerState newState) {
		playerState = newState;
	}

	public PlayerState GetState() {
		return playerState;
	}

	public string GetTag() {
		return TagConstants.PLAYER;
	}

	public Vector3 GetPosition() {
		return this.transform.position;
	}

	public void ExecuteCoroutine(IEnumerator coroutine) {
		StartCoroutine(coroutine);
	}
}
