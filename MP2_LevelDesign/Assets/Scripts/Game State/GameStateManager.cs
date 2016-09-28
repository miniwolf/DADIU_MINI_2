using UnityEngine;
using System.Collections;

public interface GameStateManager {
	/**
	 * Assign a new game state specified in {@link GameState}
	 */
	void NewState(GameState newState);

}