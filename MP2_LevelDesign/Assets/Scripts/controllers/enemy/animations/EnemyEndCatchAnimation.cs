﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyEndCatchAnimation : Action {
	private Animator animator;

	public void Execute() {
		animator.SetBool("catch", false);
	}

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}
}