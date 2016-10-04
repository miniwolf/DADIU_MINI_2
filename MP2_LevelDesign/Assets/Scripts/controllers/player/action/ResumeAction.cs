using System;
using UnityEngine;

public class ResumeAction : Action {

	private Player player;

	public ResumeAction(Player player){
		this.player = player;
	}

	public void Setup(GameObject obj){
	}

	public void Execute(){
		player.SetState(PlayerState.Running);
	}
}


