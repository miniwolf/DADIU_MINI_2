using UnityEngine;

public class MenuMusic : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("playMenuMusic", obj);
	}
}
