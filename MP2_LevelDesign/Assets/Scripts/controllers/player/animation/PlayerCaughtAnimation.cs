using UnityEngine;
using System.Collections;

public class  PlayerCaughtAnimation : Action {
	private Animator animator;
	private Player player;

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
		player = obj.GetComponent<Player>();
	}

	public void Execute() {
		animator.SetTrigger("caught");
		animator.SetBool("isThrown", true);
		player.ExecuteCoroutine(IsThrownCoroutine());
		player.ExecuteCoroutine(GetUpCoroutine());
	}

	private IEnumerator IsThrownCoroutine() {
		yield return new WaitForSeconds(1);
		animator.SetBool("isThrown", false);
	}

	private IEnumerator GetUpCoroutine() {
		yield return new WaitForSeconds(2);
		animator.SetTrigger("getUp");
	}
}
