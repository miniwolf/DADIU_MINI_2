using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private EnemyState state;
	private NavMeshController navmesh;
	//private AnimationController animation;
	//private SoundController sound;

	public Enemy(NavMeshAgent agent) {
		navmesh = new NavMeshController(agent);
		state = EnemyState.RandomWalk;
		// set animation and sound controller
	}

	public EnemyState GetState () {
		return state;
	}

	public void SetState (EnemyState newState) {
		//update state
		state = newState;
	}
}
