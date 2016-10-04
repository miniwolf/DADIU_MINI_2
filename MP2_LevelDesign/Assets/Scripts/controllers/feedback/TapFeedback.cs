using UnityEngine;
using System.Collections;

public class TapFeedback : MoveAction {
	private GameObject tapFeedback;

	public TapFeedback(GameObject tapFeedback) {
		this.tapFeedback = tapFeedback;
	}

	public void Setup(GameObject component) {
	}

	public void Execute() {
	}

	public void Execute(Vector3 pos) {
		//tapFeedback.transform.position = new Vector3(pos.x, pos.y + 0.1f, pos.z);
//			tapAnimator.Play("Scale", -1, 0f);
	}
}
