using UnityEngine;
using System.Collections;
using System;

public class Score : MonoBehaviour, Value {
	private float score = 0;

	public void DecrementValue() {
		score--;
	}

	public float GetValue() {
		return score;
	}

	public void IncrementValue() {
		score++;
	}
}
