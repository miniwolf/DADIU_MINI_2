using UnityEngine;

public class ForwardMenuFeedbackSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("menuForwardClick", obj);
	}
}
