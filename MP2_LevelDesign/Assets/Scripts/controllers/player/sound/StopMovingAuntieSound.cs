using UnityEngine;

public class StopMovingAuntieSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("stopAuntieFootsteps", obj);
	}
}
