using UnityEngine;
using System.Collections;

public interface GameStateManager {
	/// <summary>
	/// Assign a new game state specified in {@link GameState}
	/// </summary>
	/// <param name="newState">New game state.</param>
	void NewState(GameState newState);
}