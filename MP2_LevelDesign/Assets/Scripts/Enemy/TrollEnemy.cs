using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, GameEntity, Controllable {
	private EnemyState state;
	List<Controller> controllers = new List<Controller>();

	private NavMeshController navmesh;
	//private AnimationController animation;
	//private SoundController sound;

	public TrollEnemy() {
		InjectionRegister.Register(this);
		TagRegister.Register(gameObject, TagConstants.ENEMY);
		// set animation and sound controller
	}

	void Start() {
		state = EnemyState.RandomWalk;
		InjectionRegister.Register(this);
		TagRegister.Register(gameObject, TagConstants.ENEMY);
	}

	// DEBUG
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.ObstacleHit);
		}
	}

	public NavMeshController GetNavMesh() {
		foreach ( Controller controller in controllers ) {
			if ( controller.GetType() == typeof(NavMeshController) ) {
				return (NavMeshController) controller;
			}
		}
		return null;
	}

	public EnemyState GetState() {
		return state;
	}

	public void SetState(EnemyState newState) {
		state = newState;
	}

	public List<Controller> GetControllers() {
		return controllers;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}

	public string GetTag() {
		return TagConstants.ENEMY;
	}
}
