using UnityEngine;

public class DressSound : ItemCommand {
	private GameObject dress;

	public void Setup(GameObject dress) {
		this.dress = dress;
	}

	public void Execute(Collider other) {
		AkSoundEngine.PostEvent("dressPickup", dress);
	}
}
