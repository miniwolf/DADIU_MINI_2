using UnityEngine;
using System.Collections.Generic;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;

	private PlayerState playerState;
	private Life playerLife;
	private List<Controller> controllers = new List<Controller>();

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.PLAYER);
	}

	void Start() {
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
	}

	public void SetupComponents() {
	}
		
	void Update() {
		foreach(Touch touch in Input.touches) {
			cameraToGround = cam.ScreenPointToRay(touch.position);
			if ( Physics.Raycast(cameraToGround,out hit,500f,layerMask.value) ) {
				foreach ( Controller controller in controllers ) {
					controller.Move(hit.point);
				}
			}
		}

		if ( Input.GetMouseButtonDown(1) ) {
			cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
			if ( Physics.Raycast(cameraToGround, out hit,500f,layerMask.value) ) {
				foreach ( Controller controller in controllers ) {
					controller.Move(hit.point);
				}
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

	public string GetTag() {
		return TagConstants.PLAYER;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}
}
