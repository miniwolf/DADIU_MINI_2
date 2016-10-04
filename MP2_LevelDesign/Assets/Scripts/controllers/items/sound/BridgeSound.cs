using UnityEngine;

public class BridgeSound : ItemCommand {
	private GameObject bridge;

	public void Setup(GameObject bridge) {
		this.bridge = bridge;
	}

	public void Execute(Collider other) {
		if ( other.tag == TagConstants.PLAYER ) {
			AkSoundEngine.PostEvent("trollFallsIntoWater", bridge);
		}
	}
}
