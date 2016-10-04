using UnityEngine;

public class MoveActionImpl : MoveAction {
	private NavMeshAgent agent;

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
	}

	public void Execute(Vector3 pos) {
		agent.destination = pos;
		agent.Resume();
	}
}
