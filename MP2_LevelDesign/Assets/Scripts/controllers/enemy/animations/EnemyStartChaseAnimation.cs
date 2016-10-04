using UnityEngine;
using System.Collections;

public class  EnemyStartChaseAnimation : Action {
	private Animator animator;

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}

	public void Execute() {
		Debug.Log("Troll isChasing false");
		animator.SetBool("isChasing", true);
	}
}
