using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Enemy, GameEntity, Controllable, MovableCommandable {
	private EnemyState state;
	List<Controller> controllers = new List<Controller>();

	List<MovableCommand> commands = new List<MovableCommand>();

	public TrollEnemy() {
		InjectionRegister.Register(this);
		
		// set animation and sound controller
	}

	void Start() {
		state = EnemyState.RandomWalk;
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

	public void OnTriggerEnter(Collider other) {
		foreach ( MovableCommand command in commands ) {
			command.Execute(other);
		}
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

	public void AddCommand(MovableCommand command) {
		commands.Add(command);
	}

	public void SetPosition(Vector3 newPosition) {
		this.transform.position = newPosition;
	}
}
