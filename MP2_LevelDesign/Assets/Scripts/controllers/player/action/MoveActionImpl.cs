using UnityEngine;

public class MoveActionImpl : MoveAction {
	private NavMeshAgent agent;

	public override void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public override void Execute(Vector3 pos) {
		agent.destination = pos;
	}
}
