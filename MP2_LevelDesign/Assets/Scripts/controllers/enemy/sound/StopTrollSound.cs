using UnityEngine;
using System.Collections;

public class StopTrollSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("stopTrollFootsteps", obj);
	}
}
