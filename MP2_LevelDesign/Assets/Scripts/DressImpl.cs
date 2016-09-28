using UnityEngine;
using System.Collections;
using System;

public class DressImpl : MonoBehaviour, DressController {
	private GameObject dress;
	private Score score;
	private ScoreController scoreController;

	void Awake() {
		dress = GameObject.FindGameObjectWithTag("Laundry"); // TODO use constants instead
	}

	public void AddPoints() {
		score.IncrementValue();
		scoreController.ShowPoints();
	}

	public void PickUpDress() {
		dress.SetActive(false);
	}

	public void ShowFeedback() {
		// TODO sound: troll chasing sound
		// TODO Sound: pick up sound
		// TODO Feedback: number 1 shows graphically
		throw new NotImplementedException();
	}
}
