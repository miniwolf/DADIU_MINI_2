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

	/// <summary>
	/// Slows down the movement of the enemy
	/// </summary>
	void SlowDown();

	/// <summary>
	/// Teleports the enemy to a position
	/// </summary>
	/// <param name="newPosition">Position to be teleported to</param>
	void Warp(Vector3 newPosition);

	/// <summary>
	/// Speeds up the troll
	/// </summary>
	void SpeedUp();
}
