using UnityEngine;

public class LevelMusic : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("playLevelMusic", obj);
	}
}
