using UnityEngine;

public class StopMovingAuntieSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		Debug.Log("Stopping sound");
		AkSoundEngine.PostEvent("stopAuntieFootsteps", obj);
	}
}
