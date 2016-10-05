﻿using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Enemy, GameEntity, Actionable {
	public EnemyState state = EnemyState.RandomWalk;
	private Dictionary<Actions, Handler> actions = new Dictionary<Actions, Handler>();
	private Vector3 destination = Vector3.zero;

	public float slowdownTime = 2f;
	public float slowdown = 1.5f;
	public float speedUp = 1.5f;

	public float roamSpeed = 5f;
	public float chaseSpeed = 6f;

	public int thresholdSpeed = 2;
	public int thresholdChase = 2;
	public float maxSpeed = 12;

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.ENEMY);
	}

	void Start() {
		GetComponent<NavMeshAgent>().speed = roamSpeed;
	}

	void Update() {
		switch( state ) {
			case EnemyState.RandomWalk:
				ExecuteAction(Actions.ROAM);
				break;
			case EnemyState.StartChase:
				ExecuteAction(Actions.CHASE);
				break;
			case EnemyState.Chasing:
				ExecuteAction(Actions.CHASE);
				break;
			case EnemyState.WalkAway:
				ExecuteAction(Actions.WALKAWAY);
				break;
			case EnemyState.GirlCaught:
				ExecuteAction(Actions.CAUGHT);
				break;
			default:
				ExecuteAction(Actions.MOVE);
				ExecuteAction(Actions.DEBUGMOVE);
				break;
		}
	}

	public void SetupComponents() {
		foreach ( Handler action in actions.Values ) {
			action.SetupComponents(gameObject);
		}
	}

	public EnemyState GetState() {
		return state;
	}

	public void SetState(EnemyState newState) {
		state = newState;
	}

	public string GetTag() {
		return TagConstants.ENEMY;
	}

	public Vector3 GetPosition() {
		return transform.position;
	}

	public void AddAction(Actions actionName, Handler handler) {
		actions.Add(actionName, handler);
	}

	public void ExecuteAction(Actions actionName) {
		actions[actionName].DoAction();
	}

	public float GetSlowdownTime() {
		return slowdownTime;
	}

	public void SetSlowdownTime(float slowdownTime) {
		this.slowdownTime = slowdownTime;
	}

	public float GetSlowdown() {
		return slowdown;
	}

	public void SetSlowdown(float slowdown) {
		this.slowdown = slowdown;
	}

	public float GetSpeedUp() {
		return speedUp;
	}

	public void SetSpeedUp(float speedUp) {
		this.speedUp = speedUp;
	}

	public void SetDestination(Vector3 destination) {
		this.destination = destination;
	}

	public Vector3 GetDestination() {
		return destination;
	}

	public int GetThresholdSpeedup() {
		return thresholdSpeed;
	}

	public int GetThresholdChase() {
		return thresholdChase;
	}

	public float GetMaxSpeed(){
		return maxSpeed;	
	}

	public float GetRoamSpeed() {
		return roamSpeed;
	}

	public float GetChaseSpeed() {
		return chaseSpeed;
	}
}
