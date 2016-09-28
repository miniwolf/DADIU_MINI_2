using UnityEngine;
using System.Collections;
using System;

public class Score : Value {
	private float score;

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
