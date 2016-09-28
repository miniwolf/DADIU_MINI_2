using UnityEngine;
using System.Collections;
using System;

public class Life : Value {

	private float life;

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
