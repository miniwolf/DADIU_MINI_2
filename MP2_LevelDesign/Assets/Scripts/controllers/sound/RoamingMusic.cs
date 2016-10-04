using UnityEngine;

public class RoamingMusic : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("playRoamingMusic", obj);
	}
}
