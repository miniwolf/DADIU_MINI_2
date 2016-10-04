using UnityEngine;
using System.Collections;

public class StopAction : Action {
	NavMeshAgent agent;
	private Player player;

	public StopAction(Player player) {
		this.player = player;
	}

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		player.SetState(PlayerState.Idle);
		agent.Stop();
	}
}
