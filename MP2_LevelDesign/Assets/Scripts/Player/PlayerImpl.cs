using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;
	private Life life;

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
		life = new Life();
		playerState = PlayerState.Running;
	}
		
	void Update() {
		if (playerState == PlayerState.Running) {
			foreach (Touch touch in Input.touches) {
				cameraToGround = cam.ScreenPointToRay(touch.position);
				if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
					MoveTo(hit.point);
				}
			}

			if (Input.GetMouseButtonDown(1)) {
				cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
					MoveTo(hit.point);
				}
			}
		} else if (playerState == PlayerState.Idle) {
			Stunned();  
		}
	}

	public void SetState(PlayerState newState) {
		playerState = newState;
	}

	public void Stunned() {
		// Play animation & wait for trigger to change state back to Running
		if (Input.GetKeyDown(KeyCode.R)) {
			playerState = PlayerState.Running;
			foreach (Controller controller in controllers) {
				controller.Resume();
			}
		}
	}

	public void GetCaught() {
		if (playerState != PlayerState.Idle) {
			life.DecrementValue();
		}
		if (life.GetValue() > 0)
			playerState = PlayerState.Idle;
		else
			playerState = PlayerState.Dead;

		foreach (Controller controller in controllers) {
			controller.Idle();
		}
	}

	public PlayerState GetState() {
		return playerState;
	}

	public string GetTag() {
		return TagConstants.PLAYER;
	}

	public Vector3 GetPosition() {
		return this.transform.position;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}

	public void MoveTo(Vector3 position) {
		foreach ( Controller controller in controllers ) {
			controller.Move(position);
		}
	}
}
