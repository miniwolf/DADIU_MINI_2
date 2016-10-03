using UnityEngine;
using System.Collections;

public class GameStateManagerImpl : MonoBehaviour, GameStateManager {
	private GameStates gameState;
	
	public void NewState(GameStates newState) {
		if ( gameState.GetType() == newState.GetType() ) {
			return;
		}

		newState.Execute();

		gameState = newState;
	}
}
