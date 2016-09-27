using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private EnemyState state;
	private NavMeshController navmesh;
	//private AnimationController animation;
	//private SoundController sound;

	public Enemy(NavMeshAgent agent) {
		navmesh = new NavMeshController(agent);
		state = EnemyState.ObstacleHit;
		// set animation and sound controller
	}

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		navmesh = new NavMeshController(agent);
		state = EnemyState.ObstacleHit;
	}

	// DEBUG
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.RandomWalk);
		}
	}

	public EnemyState GetState () {
		return state;
	}

	public void SetState (EnemyState newState) {
		//update state
		state = newState;
	}

	public NavMeshController GetNavMesh () {
		return navmesh;
	}
}
