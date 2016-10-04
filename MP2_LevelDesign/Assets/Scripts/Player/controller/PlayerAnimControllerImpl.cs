using UnityEngine;
using System.Collections;
/// <summary>
/// This object needs to be attached to Player object in the game!
/// </summary>
public class PlayerAnimControllerImpl : MonoBehaviour {

	private const string BOOL_IS_MOVING = "isMoving";
	private const string BOOL_IS_THROWN = "isThrown";
	private const string TRIGGER_GET_UP = "getUp";
	private const string TRIGGER_CAUGHT = "caught";

	private Animator animator;

	void Start() { 
		animator = GetComponent<Animator>();	
	}

	public void PickUpItem() {
		// todo no animation
	}

	public void Idle() {
		animator.SetBool(BOOL_IS_MOVING, false);
		log("BOOL_IS_MOVING false");
	}

	public void Move(Vector3 moveTo) {
		animator.SetBool(BOOL_IS_MOVING, true);
		log("BOOL_IS_MOVING true");
	}

    public void Resume() {

    }

	public void HitObstacle(GameObject obstacle) {
		// no animation
	}

	public void Caught() {
//		Idle();
//		animator.SetTrigger(TRIGGER_CAUGHT);
//		log("caught");
//		animator.SetBool(BOOL_IS_THROWN, true);
//		log("thrown true");
//		StartCoroutine(ContinueIdleCoroutine());
	}

	private IEnumerator ContinueIdleCoroutine() {
		yield return StartCoroutine(WakeUpCoroutine());
//		animator.SetBool(BOOL_IS_MOVING, true);
	}

	private IEnumerator WakeUpCoroutine() {
//		animator.SetTrigger(TRIGGER_GET_UP);
//		log("getUp start");
		yield return  new WaitForSeconds(1f);
	}

	private void log(string msg) {
		Debug.Log(msg);
	}
}
