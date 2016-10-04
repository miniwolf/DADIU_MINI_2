using UnityEngine;

public class DressSound : ItemCommand {
	private GameObject dress;

	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	public void Execute(Collider other) {
		if ( other.tag == TagConstants.PLAYER ) {
			AkSoundEngine.PostEvent("dressPickup", dress);
		}
	}
}
