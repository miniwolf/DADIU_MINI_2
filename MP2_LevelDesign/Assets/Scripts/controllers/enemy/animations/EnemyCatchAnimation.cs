using UnityEngine;
using System.Collections;
using System;

public class EnemyCatchAnimation : Action {
	private Animator animator;

	public void Execute() {
		Debug.Log("Troll catch false");
		animator.SetBool("catch", true);
	}

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}
}
