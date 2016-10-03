using UnityEngine;
using System.Collections.Generic;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private RaycastHit hit;
	private Camera cam;
	private Ray cameraToGround;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;
    private Life life;

	private PlayerState playerState;
	private List<Controller> controllers = new List<Controller>();

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterSingle(gameObject, TagConstants.PLAYER);
	}

	void Start() {
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();
	}

	public void SetupComponents() {
        life = new Life();
        playerState = PlayerState.Running;
    }
		
	void Update() {

        if (playerState == PlayerState.Running) {
            foreach (Touch touch in Input.touches) {
                cameraToGround = cam.ScreenPointToRay(touch.position);
                if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
                    foreach (Controller controller in controllers) {
                        controller.Move(hit.point);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1)) {
                cameraToGround = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value)) {
                    foreach (Controller controller in controllers) {
                        controller.Move(hit.point);
                    }
                }
            }
        }
        else if (playerState == PlayerState.Idle) {
            Stunned();  
        }

    }

    public void SetState(PlayerState newState) {
		playerState = newState;
	}
    public void Stunned() {
        // Play animation & wait for trigger to change state back to Running
    }
    public void GetCaught() {
        life.DecrementValue();
        if(life.GetValue() > 0)
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
}
