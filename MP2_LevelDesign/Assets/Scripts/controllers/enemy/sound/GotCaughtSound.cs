using UnityEngine;

public class GotCaughtSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("trollCatchAuntie", obj);
	}
}
