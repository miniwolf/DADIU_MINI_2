using UnityEngine;
using System.Collections;

public class BridgeCommand : ItemCommand {
	public BridgeCommand() {
	}

	public void Execute(Collision other) {
		if ( other.transform.tag == TagConstants.ENEMY ) {
		}
	}
}
