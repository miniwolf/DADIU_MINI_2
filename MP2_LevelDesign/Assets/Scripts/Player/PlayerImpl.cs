using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Actionable {
	private PlayerState playerState = PlayerState.Running;
	private Dictionary<Actions, Handler> actions = new Dictionary<Actions, Handler>();

	private GameObject player;
	private GameObject tapObj;

	void Awake() {
		player = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		tapObj = GameObject.FindGameObjectWithTag(TagConstants.TAP_FEEDBACK);

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
		Debug.Log(playerState);

		switch ( playerState ) {
			case PlayerState.Running:
				ExecuteAction(Actions.MOVE);
			ExecuteAction(Actions.DEBUGMOVE);
				break;
			case PlayerState.Idle:
				ExecuteAction(Actions.STUN);
				break;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == TagConstants.TAP_FEEDBACK) {
			playerState = PlayerState.Idle;
			Debug.Log("COLLISION WITH TOUCH, CALL IDLE ANIMATION");
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
