using UnityEngine;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player {
	private PlayerState playerState;
	private Life playerLife;
	private NavMeshController navController;

	public PlayerImpl(NavMeshController controller) {
		navController = controller;
	}

	void Start() {
		if(navController == null) { // was not set by constructor
			NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
			if(agent == null) {
				Debug.Log("There's no NavMeshAgent component on Player set");
			} else {
				navController = new NavMeshController(agent);
			}
		}
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

	void OnDestroy() {
		navController = null;
	}
}
