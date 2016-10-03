using UnityEngine;
using System.Collections;

public abstract class MoveAction : Action {
	public abstract void Setup(GameObject obj);

	public void Execute() {
	}

	public abstract void Execute(Vector3 pos);
}
