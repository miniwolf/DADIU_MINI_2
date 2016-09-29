using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HowToPlayControllerImpl : MonoBehaviour, HowToPlayController {
	private CanvasScript canvas;

	void Start() {
		ResolveDependencies();
	}

	public void ReturnToMainMenu() {
		canvas.ReturnToMainMenu();
	}

	private void ResolveDependencies() {
		canvas = gameObject.GetComponentInParent<CanvasScript>();
	}
}
