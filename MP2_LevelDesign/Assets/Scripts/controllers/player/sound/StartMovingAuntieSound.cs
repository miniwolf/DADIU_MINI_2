using UnityEngine;

public class StartMovingAuntieSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		Debug.Log("Starting sound");
		AkSoundEngine.PostEvent("auntieFootsteps", obj);
	}
}
