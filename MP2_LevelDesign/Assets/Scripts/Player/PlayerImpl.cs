using UnityEngine;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player {
	private PlayerState playerState;
	private Life playerLife;
	private NavMeshController navController;
	private PlayerAnimController animController;

	public PlayerImpl(NavMeshController controller) {
		navController = controller;
	}

	void Start() {
		EnsureNavAgent();
		EnsureAnimator();
	}
		
	void Update() {

		if(navController == null) {
//			Debug.Log("No navigation controller set on Player. Did you call \"public PlayerImpl(NavMeshController controller)\" contructor?");
			return;
		}

		foreach(Touch touch in Input.touches) {
			navController.Move(touch.position);
		}

		if(Input.GetMouseButtonDown(1)) {
			navController.Move(Input.mousePosition);
		}
	}

	public void SetState(PlayerState newState) {
		playerState = newState;
	}

	public PlayerState GetState() {
		return playerState;
	}

	public Life GetLife() {
		return playerLife;
	}

	public PlayerAnimController getAnimationController() {
		return animController;
	}

	void OnDestroy() {
		navController = null;
		animController = null;
	}

	private void EnsureNavAgent() {
		if(navController == null) { // was not set by constructor
			NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
			if(agent == null) {
				Debug.Log("There's no NavMeshAgent component on Player set");
			} else {
				navController = new NavMeshController(agent);
			}
		}
	}

	private void EnsureAnimator() {
		Animator animator = gameObject.GetComponent<Animator>();
		if(animator == null) {
			Debug.Log("There's no Animator component on Player set");
		} else {
			animController = new PlayerAnimControllerImpl(animator);
		}
	}
}
