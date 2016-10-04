using UnityEngine;
using System.Collections;

public class GotCaught : Action {
	private InGameControllerImpl ingameController;
	private Player player;

	public GotCaught(InGameControllerImpl ingameController, Player player) {
		this.player = player;
		this.ingameController = ingameController;
	}

	public void Setup(GameObject obj) {
	}

	public void Execute() {	
		if ( player.GetState() == PlayerState.Idle ) {
			ingameController.DecrementLife();
		}

		((Actionable) player).ExecuteAction(Actions.STOP);
	}
}
