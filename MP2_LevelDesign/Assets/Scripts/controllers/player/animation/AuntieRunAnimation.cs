using UnityEngine;
using System.Collections;

public class AuntieRunAnimation : Action {
	private Animator animator;
	private Player player;

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}

	public void Execute() {
		animator.SetBool("isMoving", true);
	}
}
