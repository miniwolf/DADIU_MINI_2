using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Enemy, GameEntity, Controllable {
	private EnemyState state;
	List<Controller> controllers = new List<Controller>();

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.ENEMY);
	}

	// DEBUG
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.ObstacleHit);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			SetState(EnemyState.Chasing);
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

	public void SetupComponents() {
		state = EnemyState.RandomWalk;
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

	public Vector3 GetPosition() {
		return this.transform.position;
	}

	public void SetPosition(Vector3 newPosition) {
		this.transform.position = newPosition;
	}
}
