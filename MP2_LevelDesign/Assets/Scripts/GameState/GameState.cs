using UnityEngine;
using System.Collections;

public class GameState {
	public class Playing : GameStates {
		public void Execute() {
			Time.timeScale = 1.0f;
		}
	}

	public class Paused : GameStates {
		public void Execute() {
			Time.timeScale = 0.0f;
		}
	}

	public class Ended : GameStates {
		EndGame endGame;

		public Ended(){
			endGame = GameObject.FindGameObjectWithTag("GameEnd").GetComponent<EndGame>();
		}

		public void Execute(){
			endGame.BeginFade();
		}
	}
}