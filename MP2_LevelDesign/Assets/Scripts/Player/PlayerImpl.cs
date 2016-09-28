using UnityEngine;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player {
	private PlayerState playerState;
	private Life playerLife;
	private NavMeshController navController;
	private PlayerAnimController animController;
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private int layerMask = 1 << LayerConstants.GroundLayer;

	public PlayerImpl(NavMeshController controller) {
		navController = controller;
	}

	void Start() {
		EnsureNavAgent();
		EnsureAnimator();
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
	}
		
	void Update() {

		if(navController == null) {
//			Debug.Log("No navigation controller set on Player. Did you call \"public PlayerImpl(NavMeshController controller)\" contructor?");
			return;
		}

		foreach(Touch touch in Input.touches) {
			cameraToGround = cam.ScreenPointToRay(touch.position);
			if(Physics.Raycast(cameraToGround,out hit,500f)){
				navController.Move(hit.point);
			}
		}

		if(Input.GetMouseButtonDown(1)) {
			cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(cameraToGround,out hit)){
				navController.Move(hit.point);
			}
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
