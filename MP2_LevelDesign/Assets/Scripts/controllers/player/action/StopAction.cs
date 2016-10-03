using UnityEngine;
using System.Collections;

public class StopAction : Action {
	NavMeshAgent agent;

	public void Setup(GameObject obj) {
		agent = obj.GetComponent<NavMeshAgent>();
	}

	public void Execute() {
		agent.Stop();
	}
}
