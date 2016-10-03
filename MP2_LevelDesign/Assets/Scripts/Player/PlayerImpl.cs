using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;

	private PlayerState playerState;
	private List<Controller> controllers = new List<Controller>();
	private GameObject tapFeedback;
	private Renderer rend;
	private Color color;

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.PLAYER);
	}

	void Start() {
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
		tapFeedback = GameObject.FindGameObjectWithTag(TagConstants.TAP_FEEDBACK);
		rend = tapFeedback.GetComponent<Renderer>();
	}

	public void SetupComponents() {
	}

	void Update() {
		foreach (Touch touch in Input.touches) {
			cameraToGround = cam.ScreenPointToRay(touch.position);
			if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
				foreach (Controller controller in controllers) {
					controller.Move(hit.point);
				}
			}
		}

		// Mouse for debugging on a PC
		if (Input.GetMouseButtonDown(1)) {
			cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
				foreach (Controller controller in controllers) {
					controller.Move(hit.point);
					TapFeedback(hit);
				}
			}
		}
	}

	private void TapFeedback(RaycastHit hit) {
		tapFeedback.transform.position = hit.point;
		rend.material.color = Color.green;
	}

	public void SetState(PlayerState newState) {
		playerState = newState;
	}

	public PlayerState GetState() {
		return playerState;
	}

	public string GetTag() {
		return TagConstants.PLAYER;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}
}
