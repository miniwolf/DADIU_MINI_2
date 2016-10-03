using UnityEngine;
using System.Collections;

public class PlayerAnimControllerImpl : PlayerAnimController {
	private Animator animator;

	public PlayerAnimControllerImpl(Animator animator) {
		this.animator = animator;
	}

	public void PickUpItem() {
	
	}

	public void Idle() {

    }
    public void Resume() {

    }

    public void Move(Vector3 moveTo) {
	
	}

	public void HitObstacle(GameObject obstacle) {
	
	}
}
