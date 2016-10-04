using UnityEngine;
using System.Collections.Generic;

public interface Enemy {
	/// <summary>
	/// Get the current state of the enemy
	/// </summary>
	/// <returns>The state.</returns>
	EnemyState GetState();

	/// <summary>
	/// Sets the state of the enemy. See EnemyState
	/// </summary>
	/// <param name="newState">New state.</param>
	void SetState(EnemyState newState);

	/// <returns>Current position of the enemy.</returns>
	Vector3 GetPosition();

	float GetSlowdownTime();
	void SetSlowdownTime(float slowdownTime);
	float GetSlowdown();
	void SetSlowdown(float slowdown);
	float GetSpeedUp();
	void SetSpeedUp(float speedUp);
	void SetDestination(Vector3 destination);
	Vector3 GetDestination();

	int GetThresholdSpeedup();

	int GetThresholdChase();

	float GetMaxSpeed();
}
