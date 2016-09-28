using UnityEngine;
using System.Collections;

public class PlayerImpl : Player {
	private PlayerState playerState;
	private Life playerLife;

	public void SetState(PlayerState newState) {
		playerState = newState;
	}

	public PlayerState GetState() {
		return playerState;
	}
	
	public Life GetLife() {
		return playerLife;
	}
}
