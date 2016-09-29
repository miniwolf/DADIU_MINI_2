using UnityEngine;
using System.Collections;

public class NavMeshController : Controller {
	private NavMeshAgent agent;
	public float slowdown = 1.5f;
	public int slowdownTime = 3;

	public NavMeshController(NavMeshAgent agent) {
		this.agent = agent;
	}

	/// <summary>
	/// We move the agent by using the NavMeshAgent given in the constructor
	/// </summary>
	/// <param name="moveTo">Move to.</param>
	public void Move(Vector3 moveTo) {
		agent.SetDestination(moveTo);
		agent.Resume();
	}

	/// <summary>
	/// Stopping the agent from moving
	/// </summary>
	public void Idle() {
		agent.Stop();
	}

	public void HitObstacle(GameObject obstacle) {
		
	}
	
	public IEnumerator SlowDown() {
		agent.speed -= slowdown;
		yield return new WaitForSeconds(slowdownTime);

		agent.speed += slowdown;
	}
}