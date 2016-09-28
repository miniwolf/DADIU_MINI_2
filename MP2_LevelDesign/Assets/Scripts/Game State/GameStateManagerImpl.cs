using UnityEngine;
using System.Collections;

public class GameStateManagerImpl : GameStateManager{

	private GameState gameState;
	
	public void NewState(GameState newState) {

		if (gameState == newState)
			return;

		switch (newState) {
			case GameState.Playing:
				PlayGame();
				break;
			case GameState.Paused:
				PauseGame();
				break;
			case GameState.Ended:
				EndGame();
				break;
		}

		gameState = newState;
	}

	private void PlayGame() {
		switch(gameState) {
			case GameState.Paused:
				// todo unpause game
				break;
			default: // todo start a new game
				break;
		}
	}

	private void EndGame() {
		// TODO
	}

	private void PauseGame() {
		switch (gameState) {
			case GameState.Playing:
			// todo pause game
				break;
		}

	}
}
