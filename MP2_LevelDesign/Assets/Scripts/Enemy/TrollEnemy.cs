using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Enemy, GameEntity, Controllable {
	private EnemyState state;
	List<Controller> controllers = new List<Controller>();

	public TrollEnemy() {
		InjectionRegister.Register(this);
		
		// set animation and sound controller
	}

	void Start() {
		state = EnemyState.RandomWalk;
		TagRegister.Register(gameObject, TagConstants.ENEMY);
	}

	// DEBUG
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.ObstacleHit);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			SetState(EnemyState.Chasing);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			SetState(EnemyState.WalkAway);
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
}
