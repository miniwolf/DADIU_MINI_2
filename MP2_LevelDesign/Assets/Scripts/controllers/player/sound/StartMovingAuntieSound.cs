using UnityEngine;
using System.Collections;

public class StartMovingAuntieSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("auntieFootsteps", obj);
	}
}
