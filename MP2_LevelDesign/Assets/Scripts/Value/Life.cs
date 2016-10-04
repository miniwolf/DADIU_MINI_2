using UnityEngine;
using System.Collections;
using System;

public class Life : Value {
	private float life = 3;

	public void DecrementValue() {
		life--;
	}

	public float GetValue() {
		return life;
	}

	public void IncrementValue() {
		life++;
	}
}
