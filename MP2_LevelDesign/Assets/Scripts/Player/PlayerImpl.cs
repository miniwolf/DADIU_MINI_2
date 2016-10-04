﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Actionable {
	private PlayerState playerState = PlayerState.Running;
	private Dictionary<Actions, Handler> actions = new Dictionary<Actions, Handler>();

	private GameStateManager gameStateManager;
	private Animator tapAnimator;

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.PLAYER);
	}

	void Start() {
		//gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>();
		//rend = tapFeedback.GetComponent<Renderer>();
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
