using UnityEngine;
using System.Collections;

public class TapAnimation : Action {
	private Animator animator;

	public TapAnimation(Animator animator) {
		this.animator = animator;
	}

	public void Setup(GameObject obj) {
	}

	public void Execute() {
		animator.Play("Scale", -1, 0);
	}
}

