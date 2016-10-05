using UnityEngine;
using System.Collections;

public class  EnemyRoamingAnimation : Action {
	private Animator animator;

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}

	public void Execute() {
		Debug.Log("Troll roaming true");
		animator.SetBool("isRoaming", true);
	}
}
