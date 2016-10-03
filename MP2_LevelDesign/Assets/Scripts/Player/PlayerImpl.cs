using UnityEngine;
using System.Collections.Generic;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;

	private GameObject tapFeedback;
	private Renderer rend;
	private Color color;

	private PlayerState playerState;
	private List<Controller> controllers = new List<Controller>();

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
        playerState = PlayerState.Running;
    }
	void Update() {
		if (playerState == PlayerState.Running) {
			foreach (Touch touch in Input.touches) {
				cameraToGround = cam.ScreenPointToRay(touch.position);
				if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
					MoveTo(hit.point);
					TapFeedback(hit);
				}
			}

			if (Input.GetMouseButtonDown(1)) {
				cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
					MoveTo(hit.point);
					TapFeedback(hit);
				}
			}
		}
		else if (playerState == PlayerState.Idle) {
			Stunned();
		}
	}

	private void TapFeedback(RaycastHit hit) {
		tapFeedback.transform.position = hit.point;
		rend.material.color = Color.green;
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
		foreach (Controller controller in controllers) {
			controller.Move(position);
		}
	}
}






