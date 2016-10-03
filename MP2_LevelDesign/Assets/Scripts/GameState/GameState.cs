using UnityEngine;

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

	public class End : GameStates {
		public void Execute() {
			Application.LoadLevel("EndScene");
		}
	}
}