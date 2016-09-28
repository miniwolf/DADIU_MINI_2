using UnityEngine;
using System.Collections.Generic;

public class TrollEnemy : MonoBehaviour, Controllable {
	private EnemyState state;
	List<Controller> controllers = new List<Controller>();

	private NavMeshController navmesh;
	//private AnimationController animation;
	//private SoundController sound;

	public TrollEnemy() {
		InjectionRegister.Register(this);
		TagRegister.Register(TagConstants.ENEMY);
		state = EnemyState.RandomWalk;
		// set animation and sound controller
	}

	public EnemyState GetState() {
		return state;
	}

	public void SetState(EnemyState newState) {
		//update state
		state = newState;
	}

	public List<Controller> GetControllers() {
		return controllers;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}
}

