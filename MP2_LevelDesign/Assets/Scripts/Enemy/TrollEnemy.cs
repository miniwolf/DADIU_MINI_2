using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Enemy, GameEntity, Controllable {
	private EnemyState state = EnemyState.RandomWalk;
	private List<Controller> controllers = new List<Controller>();

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.ENEMY);
	}

	// DEBUG
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.RandomWalk);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			SetState(EnemyState.CatchGirl);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			SetState(EnemyState.WalkAway);
		}
	}

	public void SetupComponents() {
	}

	public EnemyState GetState() {
		return state;
	}

	public void SetState(EnemyState newState) {
		state = newState;
	}
		
	public void AddController(Controller controller) {
		controllers.Add(controller);
	}

	public string GetTag() {
		return TagConstants.ENEMY;
	}

	public Vector3 GetPosition() {
		return transform.position;
	}

	public void SlowDown() {
		StartCoroutine(GetNavMesh().SlowDown());
	}

	public void SpeedUp() {
		GetNavMesh().SpeedUp();
	}

	private NavMeshController GetNavMesh() {
		foreach ( Controller controller in controllers ) {
			if ( controller.GetType() == typeof(NavMeshController) ) {
				return (NavMeshController) controller;
			}
		}
		return null;
	}

	public void Warp(Vector3 position) {
		GetNavMesh().Teleport(position);
	}

	public void MoveTo(Vector3 target) {
		foreach ( Controller controller in controllers ) {
			controller.Move(target);
		}
	}
}
