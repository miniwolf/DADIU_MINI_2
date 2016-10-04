using UnityEngine;
using System.Collections;

public class GameState {
	public class Playing : GameStates {
		public void Execute() {
			Time.timeScale = 1.0f;
			Action action = new LevelMusic();
			action.Execute();
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
			endGame = GameObject.FindGameObjectWithTag("FadingObj").GetComponent<EndGame>();
		}

		public void Execute(){
			endGame.BeginFade();
		}
	}
}