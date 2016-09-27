using UnityEngine;

/**
 * The controller is responsible for response control
 */
public interface Controller {
	/**
	 * Called when the state has changed to moving
	 */
	void Move(Vector3 moveTo);

	/**
	 * Called when the state has changed to idle
	 */
	void Idle();
}