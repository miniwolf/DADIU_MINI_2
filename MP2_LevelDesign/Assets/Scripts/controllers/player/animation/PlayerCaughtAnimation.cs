using UnityEngine;
using System.Collections;

public class  PlayerCaughtAnimation : Action {
	private Animator animator;
	private Player player;
	private GameObject playerObj, enemyObj;

	public PlayerCaughtAnimation(GameObject enemyObj, GameObject playerObj) {
		this.enemyObj = enemyObj;
		this.playerObj = playerObj;
	}

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
		// look in the right direction
		playerObj.transform.rotation = Quaternion.LookRotation(playerObj.transform.position - enemyObj.transform.position);
		NavMeshAgent agent = playerObj.GetComponent<NavMeshAgent>();
//		 Vector3.Le(playerObj.transform.position, enemyObj.transform.position);
//		Debug.Log("Player pos : " + playerObj.transform.position);
//		Debug.Log("Enemy pos : " + enemyObj.transform.position);
		Vector3  movePos = playerObj.transform.position + (enemyObj.transform.position - playerObj.transform.position);
//		Debug.Log("movePos pos : " + movePos);
		agent.Move(movePos);
		yield return new WaitForSeconds(1);
		animator.SetBool("isThrown", false);
	}

	private IEnumerator GetUpCoroutine() {
		yield return new WaitForSeconds(2);
		animator.SetTrigger("getUp");
	}

	// todo add direction of movement
//	private IEnumerator MoveCoroutine() {




//
//		for(int i = 0; i < 5000; i++) {
//			playerObject.transform.position = new Vector3(originalPos.x + ((float) 1 * Time.deltaTime), originalPos.y, originalPos.z);
//			Debug.Log("New Pos" + playerObject.transform.position);
//			yield return new Wi();
//		}
//	}

}
