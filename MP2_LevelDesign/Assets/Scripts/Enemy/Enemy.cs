using UnityEngine;
using System.Collections.Generic;

<<<<<<< HEAD
public interface Enemy {
	EnemyState GetState();

	void SetState(EnemyState newState);

	List<Controller> GetControllers();
=======
public class Enemy : MonoBehaviour {
	private EnemyState state;
	private NavMeshController navmesh;
	private EnemyAnimController animController;
	//private SoundController sound;
	
	public Enemy(NavMeshAgent agent) {
		navmesh = new NavMeshController(agent);
		state = EnemyState.ObstacleHit;
		// set animation and sound controller
	}

	void Start() {
		EnsureAnimator();
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		navmesh = new NavMeshController(agent);
		state = EnemyState.RandomWalk;
	}

	// DEBUG
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SetState(EnemyState.RandomWalk);
		}
	}

	public EnemyState GetState() {
		return state;
	}

	public void SetState(EnemyState newState) {
		//update state
		state = newState;
	}

	public NavMeshController GetNavMesh() {
		return navmesh;
	}

	private void EnsureAnimator() {
		Animator animator = gameObject.GetComponent<Animator>();
		if (animator == null) {
			Debug.Log("There's no Animator component on Enemy set");
		} else {
			animController = new EnemyAnimControllerImpl(animator);
		}
	}

	void OnDestroy() {
		//  todo maybe release animController.animator?
		animController = null;
	}

>>>>>>> develop
}
