﻿using UnityEngine;

public class BackwardMenuFeedbackSound : Action {
	private GameObject obj;

	public void Setup(GameObject obj) {
		this.obj = obj;
	}

	public void Execute() {
		AkSoundEngine.PostEvent("menuBackwardClick", obj);
	}
}
