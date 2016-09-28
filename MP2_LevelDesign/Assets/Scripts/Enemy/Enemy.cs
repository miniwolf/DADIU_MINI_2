using UnityEngine;
using System.Collections.Generic;

public interface Enemy {
	EnemyState GetState();
	void SetState(EnemyState newState);
	List<Controller> GetControllers();
	NavMeshController GetNavMesh();

	Vector3 GetPosition();
}
