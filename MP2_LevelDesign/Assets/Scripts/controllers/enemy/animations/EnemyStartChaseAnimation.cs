﻿using UnityEngine;
using System.Collections;

public class  EnemyStartChaseAnimation : Action {
	private Animator animator;

	public void Setup(GameObject obj) {
		animator = obj.GetComponentInChildren<Animator>();
	}

	public void Execute() {
		animator.SetBool("isChasing", true);
	}
}
