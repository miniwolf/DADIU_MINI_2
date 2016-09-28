using UnityEngine;
using System.Collections.Generic;

public class PlayerImpl : MonoBehaviour, Player, GameEntity, Controllable {
	private PlayerState playerState;
	private Life playerLife;
	private List<Controller> controllers = new List<Controller>();

	public PlayerImpl() {
		InjectionRegister.Register(this);
		TagRegister.Register(gameObject, TagConstants.PLAYER);
	}

	void Update() {
		foreach ( Touch touch in Input.touches ) {
			foreach ( Controller controller in controllers ) {
				controller.Move(touch.position);
			}
		}

		if ( Input.GetMouseButtonDown(1) ) {
			foreach ( Controller controller in controllers ) {
				controller.Move(Input.mousePosition);
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
		return gameObject.transform.tag;
	}

	public void AddController(Controller controller) {
		controllers.Add(controller);
	}
}
