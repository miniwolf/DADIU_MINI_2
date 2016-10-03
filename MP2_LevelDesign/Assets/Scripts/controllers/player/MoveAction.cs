using UnityEngine;
using System.Collections;

public interface MoveAction : Action {
	void Execute(Vector3 pos);
}
