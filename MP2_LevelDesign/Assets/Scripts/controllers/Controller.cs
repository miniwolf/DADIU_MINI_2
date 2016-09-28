using UnityEngine;

/// <summary>
/// The controller is responsible for response control
/// </summary>
public interface Controller {
	/// <summary>
	/// Called when the state has changed to moving
	/// </summary>
	/// <param name="moveTo">Vector3 we move to</param>
	void Move(Vector3 moveTo);

	/// <summary>
	/// Called when the state has changed to idle
	/// </summary>
	void Idle();

	/// <summary>
	/// Hits the obstacle.
	/// </summary>
	/// <param name="obstacle">Obstacle.</param>
	void HitObstacle(GameObject obstacle);
}